﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyMonkeyServerLite.Data;
using MoneyMonkeyServerLite.Data.Models;

namespace MoneyMonkeyServerLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PurchasesController(AppDbContext context)
        {
            _context = context;
        }

        /*
        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> Getpurchases()
        {
          if (_context.purchases == null)
          {
              return NotFound();
          }
            return await _context.purchases.ToListAsync();
        }
        */

        // GET: api/Purchases/01/2023
        [HttpGet("{month:int}/{year:int}")]
        public async Task<ActionResult<List<Purchase>>> GetPurchasesByDate(int month, int year)
        {
            if (_context.purchases == null)
            {
                return NotFound();
            }
            List<Purchase> purchase = new List<Purchase>();
            purchase = _context.purchases.Where(x => x.Date.Year==year && x.Date.Month==month).ToList();

            if (purchase == null)
            {
                return NotFound();
            }

            return await Task.FromResult(purchase);
        }

        // GET: api/Purchases/yearly/2023
        [HttpGet("yearly/{year:int}")]
        public async Task<ActionResult<List<Purchase>>> GetPurchasesByYear(int year)
        {
            if (_context.purchases == null)
            {
                return NotFound();
            }
            List<Purchase> purchase = new List<Purchase>();
            purchase = _context.purchases.Where(x => x.Date.Year == year).ToList();

            if (purchase == null)
            {
                return NotFound();
            }

            return await Task.FromResult(purchase);
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
          if (_context.purchases == null)
          {
              return NotFound();
          }
            var purchase = await _context.purchases.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        // PUT: api/Purchases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Purchases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
          if (_context.purchases == null)
          {
              return Problem("Entity set 'AppDbContext.purchases'  is null.");
          }
            _context.purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            if (_context.purchases == null)
            {
                return NotFound();
            }
            var purchase = await _context.purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseExists(int id)
        {
            return (_context.purchases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
