using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly StoreContext _storeContext;

    public ProductsController(StoreContext storeContext)
    {
      this._storeContext = storeContext;
    }



    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var product = await this._storeContext.Products.ToListAsync();
      return product;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await this._storeContext.Products.FindAsync();
    }
  }
}