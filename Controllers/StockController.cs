using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Mappers;
using api.Dtos.Stock;
using api.Interface;
using Microsoft.EntityFrameworkCore;
using net_tutorial.Helpers;

namespace api.Controllers
{
    [Route("api/v1/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo ?? throw new ArgumentNullException(nameof(stockRepo));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query){
            var stocks = await _stockRepo.GetAllAsync(query);
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock = await _stockRepo.GetByIdAsync(id);
            if(stock == null){
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDto StockDto)  
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var stockModel = StockDto.ToStockFromCreateDto();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStockRequestDto updateDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
            if(stockModel == null){
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var commentsToDelete = _context.Comments.Where(c => c.StockId == id);
            _context.Comments.RemoveRange(commentsToDelete); 

            var stockModel = await _stockRepo.DeleteAsync(id);
            if(stockModel == null){
                return NotFound();
            }
            return NoContent();
        }
    }
}