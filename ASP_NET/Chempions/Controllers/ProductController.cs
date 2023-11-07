using Chempions.BindingModel;
using Chempions.Common.DAO;
using Chempions.Validate;
using Chempions.Data.Sql;
using Chempions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

namespace Chempions.Controllers;

[Route("api/[controller]")]

public class ProductController : Controller
{
    private readonly ChempionsDbContext _context;
    private readonly IHubContext<NotificationHub> _hubContext;

    public ProductController(ChempionsDbContext context, IHubContext<NotificationHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }

    [HttpGet("{IdProd:min(1)}", Name = "GetProductById")]
    public async Task<IActionResult> GetProductById(int IdProd)
    {
        var product = await _context.Product.FirstOrDefaultAsync(x => x.Idprod == IdProd);
        if (product != null)
        {
            return Ok(new ProductViewModel()
            {
                Idprod = product.Idprod,
                Nazwa = product.Nazwa,
                Producent = product.Producent,
                Kategoria = product.Kategoria,
                CenaNetto = product.CenaNetto,
                CenaBrutto =product.CenaBrutto
            });
        }

        return NotFound();
    }
    
    [HttpGet("name/{productName}", Name = "GetProductByName")]
    public async Task<IActionResult> GetProductByName(string productName)
    {
        var product = await _context.Product.FirstOrDefaultAsync(x => x.Nazwa == productName);
        if (product != null)
        {
            return Ok(new ProductViewModel()
            {
                Idprod = product.Idprod,
                Nazwa = product.Nazwa,
                Producent = product.Producent,
                Kategoria = product.Kategoria,
                CenaNetto = product.CenaNetto,
                CenaBrutto =product.CenaBrutto
            });
        }

        return NotFound();
    }

    [ValidationModel]
    [Consumes("application/x-www-form-urlencoded")]
    [HttpPost("create",Name="AddProduct")]
    public async Task<IActionResult> Post([FromForm] AddProduct addProduct)
    {
        var product = new Product
        {
            Nazwa = addProduct.Nazwa,
            Producent = addProduct.Producent,
            Kategoria = addProduct.Kategoria,
            CenaNetto = addProduct.CenaNetto,
            CenaBrutto = addProduct.CenaBrutto
        };
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        return Created(product.Idprod.ToString(), new ProductViewModel
        {
            Idprod = product.Idprod,
            Nazwa = product.Nazwa,
            Producent = product.Producent,
            Kategoria = product.Kategoria,
            CenaNetto = product.CenaNetto,
            CenaBrutto =product.CenaBrutto
        });
    }

    [ValidationModel]
    [HttpPatch("edit/{IdProd:min(1)}", Name = "EditProduct")]
    public async Task<IActionResult> EditProduct([FromBody] EditProduct editProduct, int prodId)
    {
        var product = await _context.Product.FirstOrDefaultAsync(x => x.Idprod == prodId);
            product.Nazwa = editProduct.Nazwa;
            product.Producent = editProduct.Producent;
            product.CenaNetto = editProduct.CenaNetto;
            product.CenaBrutto = editProduct.CenaBrutto;
            await _context.SaveChangesAsync();
            return NoContent();
            return Ok(new ProductViewModel
            {
                    Idprod = prodId,
                    Nazwa = product.Nazwa,
                    Producent = product.Producent ,
                    CenaNetto= product.CenaNetto,
                    CenaBrutto= product.CenaBrutto,
                    
            });
            return NoContent();
        
    }

    [ValidationModel]
    [HttpDelete("delete/{IdProd:min(1)}", Name = "DelById")]
    public async Task<IActionResult> DelById(int IdProd)
    {
        var product = await _context.Product.FirstOrDefaultAsync(x => x.Idprod == IdProd);
        if (product != null)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ProductDeleted", IdProd);
            return Ok();
        }

        return NotFound();
    }

  
    }

