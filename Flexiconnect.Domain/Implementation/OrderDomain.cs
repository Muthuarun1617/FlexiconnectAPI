using Azure;
using Dapper;
using Flexiconnect.Domain.Common;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces;
using Flexiconnect.Shared.Constants;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Implementation
{
    public class OrderDomain : IOrderDomain
    {
        private readonly IGenericRepository<Order> _genericRepository;
        private readonly IGenericRepository<string> _genericRepositorystg;
        public OrderDomain(IGenericRepository<Order> genericRepository, IGenericRepository<string> genericRepositorystg)
        {
            _genericRepository = genericRepository;
            _genericRepositorystg = genericRepositorystg;
        }
        public async Task<Order> GetDealerByRole(Order dealerRequest)
        {


            Order dealers = new Order();

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserName", dealerRequest.Username);
            dynamicParameters.Add("UserRole", dealerRequest.Role);
            dynamicParameters.Add("SearchText", dealerRequest.SearchText);
            dynamicParameters.Add("PageNumber", dealerRequest.currentPage);
            dynamicParameters.Add("PageSize", dealerRequest.PageSize);

            // Add output parameters
            dynamicParameters.Add("HasMore", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            dynamicParameters.Add("TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);


            dealers.Dealers = (List<DomainDealer>?)await _genericRepository.GetAsync(DBConstants.GetDealerByRole, dynamicParameters);
            //Trim All Extra Space contain in Field
            TrimHelper.TrimAllStringsInList(dealers.Dealers);
            // Read output values
            bool hasMore = dynamicParameters.Get<bool>("HasMore");
            int totalRecords = dynamicParameters.Get<int>("TotalRecords");

            // Now map to your response DTO
            dealers.currentPage = dealerRequest.currentPage;
            dealers.PageSize = dealerRequest.PageSize;
            dealers.hasMore = hasMore;
            dealers.totalRecords = totalRecords;


            return dealers;
        }

        public async Task<Order> GetProductFilter(string DealerCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            Order order = new Order();
            dynamicParameters.Add("DealerCode", DealerCode);
            var response = await _genericRepository.GetAsync(DBConstants.GetFilterProduct, dynamicParameters);

            var categories = new HashSet<string>();
            var subCategories = new Dictionary<string, HashSet<string>>();

            foreach (var row in response)
            {
                categories.Add(row.CATEGORY?.Trim());

                var category = row.CATEGORY?.Trim();
                var subCategory = row.SubCategory?.Trim();

                if (!subCategories.ContainsKey(category))
                    subCategories[category] = new HashSet<string>();

                subCategories[category].Add(subCategory);
            }
            order.DealerCode = DealerCode;
            order.Categories = categories.ToList();
            order.SubCategories = subCategories.ToDictionary(k => k.Key, v => v.Value.ToList());

            return order;
        }

        public async Task<Order> GetProductCatalogue(Order ProductCatalogue)
        {
            Order order = new Order();
            var categoriesTable = ConvertToDataTable.ToStringListTable(ProductCatalogue.SelectedCategories);
            var subCategoriesTable = ConvertToDataTable.ToStringListTable(ProductCatalogue.SelectedSubCategories);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("DealerCode", ProductCatalogue.DealerCode);
            dynamicParameters.Add("SearchText", ProductCatalogue.SearchText);
            dynamicParameters.Add("CurrentPage", ProductCatalogue.currentPage);
            dynamicParameters.Add("PageSize", ProductCatalogue.PageSize);
            dynamicParameters.Add("Categories", categoriesTable.AsTableValuedParameter("dbo.StringList"));
            dynamicParameters.Add("SubCategories", subCategoriesTable.AsTableValuedParameter("dbo.StringList"));

            dynamicParameters.Add("HasMore", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            dynamicParameters.Add("TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

            order.Products = (List<string>)await _genericRepositorystg.GetAsync(DBConstants.GetProductCatalogue, dynamicParameters);
            // Read output values
            bool hasMore = dynamicParameters.Get<bool>("HasMore");
            int totalRecords = dynamicParameters.Get<int>("TotalRecords");

            order.currentPage = ProductCatalogue.currentPage;
            order.PageSize = ProductCatalogue.PageSize;
            order.hasMore = hasMore;
            order.totalRecords = totalRecords;

            // Convert categories/subcategories to DataTables
            return order;
        }

        public async Task<Order> GetFrequentlyOrderProducts(string DealerCode)
        {

            Order order = new Order();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("DealerCode", DealerCode);
            order.Products = (List<string>)await _genericRepositorystg.GetAsync(DBConstants.GetFrequentlyOrderProducts, dynamicParameters);

            order.DealerCode = DealerCode;


            return order;
        }

        public async Task<Order> GetProductDetailsByVariant(string DealerCode, string Color, string Size, string Dimension, decimal Thickness)
        {
            Order order = new Order();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("DealerCode", DealerCode);
            dynamicParameters.Add("Color", Color);
            dynamicParameters.Add("Size", Size);
            dynamicParameters.Add("Dimension", Dimension);
            dynamicParameters.Add("Thickness", Thickness);
            var response = await _genericRepository.GetAsync(DBConstants.ProductDetailsByVariant, dynamicParameters);
            order = response.FirstOrDefault();

            return order;


        }

        public async Task<Order> GetProductsVariant(string DealerCode, string Product)
        {
            Order response = new Order();
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("DealerCode", DealerCode);
                dynamicParameters.Add("SubProductHierarchy", Product);
                var responses = (await _genericRepository.GetAsync(DBConstants.ProductVariant, dynamicParameters)) as IEnumerable<ProductVariantRow>;
                var order = new Order
                {
                    DealerCode = DealerCode,
                    Product = Product,
                    ProductDescription = $"{Product} sample description", // You can get it from DB if available
                    Colors = new List<string>(),
                    Images = new Dictionary<string, List<string>>(),
                    Sizes = new Dictionary<string, List<string>>(),
                    Dimensions = new Dictionary<string, Dictionary<string, List<string>>>(),
                    Thickness = new Dictionary<string, Dictionary<string, Dictionary<string, List<int>>>>()
                };

                foreach (var row in responses)
                {
                    string color = row.ColorName;
                    string size = row.Size;
                    string dimension = row.Dimension;
                    int thickness = int.Parse(row.Thickness.ToString());

                    // 1. Colors
                    if (!order.Colors.Contains(color))
                    {
                        order.Colors.Add(color);
                        // Optional: add images for demo purpose
                        order.Images[color] = new List<string>
            {
                "https://via.placeholder.com/150",
                "https://via.placeholder.com/200"
            };
                    }

                    // 2. Sizes
                    if (!order.Sizes.ContainsKey(color))
                        order.Sizes[color] = new List<string>();
                    if (!order.Sizes[color].Contains(size))
                        order.Sizes[color].Add(size);

                    // 3. Dimensions
                    if (!order.Dimensions.ContainsKey(color))
                        order.Dimensions[color] = new Dictionary<string, List<string>>();
                    if (!order.Dimensions[color].ContainsKey(size))
                        order.Dimensions[color][size] = new List<string>();
                    if (!order.Dimensions[color][size].Contains(dimension))
                        order.Dimensions[color][size].Add(dimension);

                    // 4. Thickness
                    if (!order.Thickness.ContainsKey(color))
                        order.Thickness[color] = new Dictionary<string, Dictionary<string, List<int>>>();
                    if (!order.Thickness[color].ContainsKey(size))
                        order.Thickness[color][size] = new Dictionary<string, List<int>>();
                    if (!order.Thickness[color][size].ContainsKey(dimension))
                        order.Thickness[color][size][dimension] = new List<int>();
                    if (!order.Thickness[color][size][dimension].Contains(thickness))
                        order.Thickness[color][size][dimension].Add(thickness);
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            return response;
        }
    }
}
