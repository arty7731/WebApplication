using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Core.DTO;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Web.Models.Category;

namespace WebApplication.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager categoryManager;
        private readonly IMapper mapper;

        public CategoryController(ICategoryManager categoryManager,
            IMapper mapper)
        {
            this.categoryManager = categoryManager;
            this.mapper = mapper;
        }

        // GET: Category
        public ActionResult All()
        {
            var categories = this.categoryManager.GetAll();
            var result = this.mapper.Map<IEnumerable<CategoryDto>, IEnumerable<ShortCategoryViewModel>>(categories);

            return View(result);
        }
    }
}