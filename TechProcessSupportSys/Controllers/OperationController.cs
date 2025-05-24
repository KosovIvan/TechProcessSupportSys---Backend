using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using TechProcessSupportSys.Attributes;
using TechProcessSupportSys.Dtos.Operation;
using TechProcessSupportSys.Dtos.TechProcess;
using TechProcessSupportSys.Extentions;
using TechProcessSupportSys.Interfaces;
using TechProcessSupportSys.Models;
using TechProcessSupportSys.QueryObjects;

namespace TechProcessSupportSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IAutomapper automapper;
        private readonly IOperationRepository operationRepo;
        private readonly UserManager<User> userManager;

        public OperationController(IAutomapper automapper, IOperationRepository operationRepo, UserManager<User> userManager)
        {
            this.automapper = automapper;
            this.operationRepo = operationRepo;
            this.userManager = userManager;
        }

        [HttpGet("{processId:int}")]
        public async Task<IActionResult> GetOperations([FromRoute] int processId)
        {
            string userId = "";
            bool isAdmin = false;
            var username = User.GetUsername();
            if (username != null)
            {
                var user = await userManager.FindByNameAsync(username);
                userId = user!.Id;
                isAdmin = await userManager.IsInRoleAsync(user, "Admin");
            }

            var operations = await operationRepo.GetAllAsync(processId, isAdmin, userId);

            if (operations == null) return NotFound();

            var operationsDto = operations.Select(o => automapper.Map<OperationDto, Operation>(o)).ToList();

            return Ok(operationsDto);
        }

        [HttpGet("read-operation/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            string userId = "";
            bool isAdmin = false;
            var username = User.GetUsername();
            if (username != null)
            {
                var user = await userManager.FindByNameAsync(username);
                userId = user!.Id;
                isAdmin = await userManager.IsInRoleAsync(user, "Admin");
            }

            var operation = await operationRepo.GetByIdAsync(isAdmin, userId, id);

            if (operation == null) return NotFound();

            return Ok(automapper.Map<OperationExtendedDto, Operation>(operation));
        }

        [HttpPost("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] CreateOperationDto createOperationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (createOperationDto.StepOrder == "000") return BadRequest("Номер операции не должен быть равен 000");
                if (await operationRepo.IsStepOrderDublicate(id, createOperationDto.StepOrder)) return BadRequest("Такой номер операции уже есть");
                
                var username = User.GetUsername();
                var user = await userManager.FindByNameAsync(username);

                var userId = await operationRepo.GetUserId(id);
                if (userId == null) return NotFound();
                if (userId != user.Id) return Forbid();

                if (createOperationDto.StepOrder.IsNullOrEmpty())
                {
                    var result = operationRepo.CreateStepOrder(id);
                    if (result == null) return BadRequest("Превышено максимальное количество операций(999)");
                    createOperationDto.StepOrder = result;
                }

                var operation = automapper.Map<Operation, CreateOperationDto>(createOperationDto);
                operation.ProcessId = id;
                operation.Author = username;
                operation.UpdatedAt = DateTime.UtcNow;
                operation.UpdatedBy = username;

                await operationRepo.CreateAsync(operation);

                return CreatedAtAction(nameof(GetById), new { id = operation.Id }, automapper.Map<OperationDto, Operation>(operation));

            }
            /*catch (AggregateException ex)
            {
                StringBuilder  sb = new StringBuilder();
                //return BadRequest(ex.InnerException.Message);
                foreach (var err in ex.InnerExceptions)
                {
                    sb.Append(err.Message.ToString() + ";\n");
                }
                return BadRequest(sb.ToString());
            }*/
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOperationDto updateOperationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (updateOperationDto.StepOrder == "000") return BadRequest("Номер операции не должен быть равен 000");
                if (await operationRepo.IsStepOrderDublicateByOperationId(id, updateOperationDto.StepOrder)) return BadRequest("Такой номер операции уже есть");

                var username = User.GetUsername();
                var user = await userManager.FindByNameAsync(username!);
                var userId = await userManager.IsInRoleAsync(user, "Admin") ? null : user!.Id;

                var operation = automapper.Map<Operation, UpdateOperationDto>(updateOperationDto);
                operation.UpdatedAt = DateTime.UtcNow;
                operation.UpdatedBy = username;

                var updated = await operationRepo.UpdateAsync(userId, id, operation);

                if (updated == null) return NotFound();
                
                 return Ok(automapper.Map<OperationDto, Operation>(updated));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var username = User.GetUsername();
            var user = await userManager.FindByNameAsync(username!);
            var userId = await userManager.IsInRoleAsync(user, "Admin") ? null : user!.Id;

            var deleted = await operationRepo.DeleteAsync(userId, id);

            if (deleted == null) return NotFound();

            return NoContent();
        }
    }
}