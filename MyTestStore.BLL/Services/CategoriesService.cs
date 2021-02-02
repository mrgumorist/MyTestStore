using AutoMapper;
using MyTestStore.BLL.DTOs;
using MyTestStore.BLL.HelperModels;
using MyTestStore.BLL.Intefaces;
using MyTestStore.DLL.Entities;
using MyTestStore.DLL.Interfaces;
using MyTestStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestStore.BLL.Services
{
    public class CategoriesService:ICategoriesService
    {
        private readonly IRepository<Client> _clientsRepository;
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IRepository<Category> _categoriesRepository;
        private readonly IRepository<ProductInPurchase> _purchaseProductsRepository;
        private readonly IRepository<Product> _productsRepository;
        private readonly IMapper _mapper;

        public CategoriesService(IRepository<Client> clientsRepository, IRepository<Purchase> purchaseRepository, IRepository<Category> categoriesRepository, IMapper mapper, IRepository<ProductInPurchase> purchaseProductsRepository, IRepository<Product> productsRepository)
        {
            this._clientsRepository = clientsRepository;
            this._purchaseRepository = purchaseRepository;
            this._categoriesRepository = categoriesRepository;
            this._purchaseProductsRepository = purchaseProductsRepository;
            this._productsRepository = productsRepository;
            this._mapper = mapper;
        }

        public ActionResult GetInDemandCategories(int clientID)
        {
            ActionResult result = new ActionResult();
            try
            {
                var purchases = _purchaseRepository.Find(x => x.ClientID == clientID).ToList();
                if (purchases.Count != 0)
                {
                    List<HelperProduct> helperProducts = new List<HelperProduct>();
                    foreach (var item in purchases)
                    {
                        var purchasesProducts = _purchaseProductsRepository.Find(x => x.PurchaseID == item.ID).ToList();
                        foreach (var purchaseProduct in purchasesProducts)
                        {
                            HelperProduct helperProduct = new HelperProduct();
                            helperProduct.ProductID = purchaseProduct.ProductID;
                            helperProduct.Count = purchaseProduct.Count;
                            helperProducts.Add(helperProduct);
                        }
                    }
                    List<HelperProductWithCategory> productsList = new List<HelperProductWithCategory>();
                    foreach (var item in helperProducts)
                    {
                        productsList.Add(new HelperProductWithCategory()
                        {
                            CategoryName = _categoriesRepository.Get(_productsRepository.Get(item.ProductID).CategoryID).Name,
                            Count = item.Count,
                            ProductID = item.ProductID
                        }) ;
                    }
                    var categoryGroups = from category in productsList
                                         group category by category.CategoryName;
                    List<CategoryStatisticModel> categoryStatistics = new List<CategoryStatisticModel>();
                    foreach (IGrouping<string, HelperProductWithCategory> g in categoryGroups)
                    {
                        CategoryStatisticModel model = new CategoryStatisticModel();
                        model.CategoryName=g.Key;
                        int count = 0;
                        foreach (var t in g)
                        {
                            count += t.Count;
                        }
                        model.Count = count;
                        categoryStatistics.Add(model);
                    }
                    result.Description = "Success";
                    result.IsSuccessfull = true;
                    result.ResObj = categoryStatistics;
                }
                else
                {
                    result.IsSuccessfull = false;
                    result.Description = "Client was not found";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                result.Description = "Error: " + ex.Message;
            }
            return result;
        }
    }
}
