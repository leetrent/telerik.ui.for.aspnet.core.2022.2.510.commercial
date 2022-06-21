using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers.DropDownTree
{
    public partial class DropDownTreeController : BaseController
    {
        [Demo]
        public ActionResult Local_Data_Binding()
        {
            ViewBag.inlineDefault = Local_Data_Binding_Get_Default_Inline_Data();
            ViewBag.inline = Local_Data_Binding_Get_Inline_Data();
            return View();
        }

        private IEnumerable<DropDownTreeItemModel> Local_Data_Binding_Get_Default_Inline_Data()
        {
            List<DropDownTreeItemModel> inlineDefault = new List<DropDownTreeItemModel>
                {
                    new DropDownTreeItemModel
                    {
                        Text = "Furniture",
                        Items = new List<DropDownTreeItemModel>
                        {
                            new DropDownTreeItemModel()
                            {
                                Text = "Tables & Chairs"
                            },
                            new DropDownTreeItemModel
                            {
                                 Text = "Sofas"
                            },
                            new DropDownTreeItemModel
                            {
                                 Text = "Occasional Furniture"
                            }
                        }
                    },
                    new DropDownTreeItemModel
                    {
                        Text = "Decor",
                        Items = new List<DropDownTreeItemModel>
                        {
                            new DropDownTreeItemModel()
                            {
                                Text = "Bed Linen"
                            },
                            new DropDownTreeItemModel
                            {
                                 Text = "Curtains & Blinds"
                            },
                            new DropDownTreeItemModel
                            {
                                 Text = "Carpets"
                            }
                        }
                    }
                };

            return inlineDefault;
        }

        private IEnumerable<CategoryItem> Local_Data_Binding_Get_Inline_Data()
        {
            List<CategoryItem> inline = new List<CategoryItem>
                {
                    new CategoryItem
                    {
                        CategoryName = "Storage",
                        SubCategories = new List<SubCategoryItem>
                        {
                            new SubCategoryItem()
                            {
                                SubCategoryName = "Wall Shelving"
                            },
                            new SubCategoryItem
                            {
                                 SubCategoryName = "Floor Shelving"
                            },
                            new SubCategoryItem
                            {
                                 SubCategoryName = "Kids Storag"
                            }
                        }
                    },
                    new CategoryItem
                    {
                        CategoryName = "Lights",
                        SubCategories = new List<SubCategoryItem>
                        {
                            new SubCategoryItem()
                            {
                                SubCategoryName = "Ceiling"
                            },
                            new SubCategoryItem
                            {
                                 SubCategoryName = "Table"
                            },
                            new SubCategoryItem
                            {
                                 SubCategoryName = "Floor"
                            }
                        }
                    }
                };

            return inline;
        }
    }
}
