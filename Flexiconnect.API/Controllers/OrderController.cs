using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Implementations;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Flexiconnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices actionOrderServices)
        {
            _orderServices = actionOrderServices;
        }
        [HttpPost("GetDealersByRole")]
        public async Task<IActionResult> GetDealersByRole(DealerRequest dealerRequest)
        {
            OrderDto response = new OrderDto();

            try
            {
                response = await _orderServices.GetDealerByRole(dealerRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }

        [HttpGet("GetProductFilter")]
        public async Task<IActionResult> GetProductFilter(string DealerCode)
        {
            DealerCategory response = new DealerCategory();
            try
            {
                response = await _orderServices.GetProductFilter(DealerCode);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }
        [HttpPost("GetProductCatelogue")]
        public async Task<IActionResult> GetProductCatelogue(ProductCatelogueDto dealerCategory)
        {
            ResponseProductCatelogue response = new ResponseProductCatelogue();
            try
            {
                response = await _orderServices.GetProductCatalogue(dealerCategory);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }
        [HttpGet("GetFrequentlyOrderedProducts")]
        public async Task<IActionResult> GetFrequentlyOrderedProducts(string DealerCode)
        {
            FrequentlyOrderProducutsDto response = new FrequentlyOrderProducutsDto();
            try
            {
                response = await _orderServices.GetFrequentlyOrderProducts(DealerCode);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }
        }
        [HttpGet("GetProductDetailsByVariant")]
        public async Task<IActionResult> GetProductDetailsByVariant(string DealerCode, string Color, string Size, string Dimension, decimal Thickness)
        {
            ProductDetailsByVariantDto productDetailsByVariant = new ProductDetailsByVariantDto();
            try
            {
                productDetailsByVariant = await _orderServices.GetProductDetailsByVariant(DealerCode, Color, Size, Dimension, Thickness);
                return Ok(productDetailsByVariant);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = MessageConstants.ErrorResponse });
            }

        }
        //[HttpGet("GetProductVariant")]
        //public async Task<IActionResult> GetProductVariant(string DealerCode, string Product)
        //{
        //    ProductVariant productVariant = new ProductVariant();
        //    try
        //    {
        //        productVariant = await _orderServices.GetProductsVariant(DealerCode, Product);
        //        return Ok(productVariant);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { error = MessageConstants.ErrorResponse });
        //    }
        //}
    }
}
