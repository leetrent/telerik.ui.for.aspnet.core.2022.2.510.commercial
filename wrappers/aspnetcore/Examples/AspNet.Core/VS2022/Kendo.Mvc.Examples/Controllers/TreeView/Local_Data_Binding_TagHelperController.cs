using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.TagHelpers;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeViewController : BaseController
    {
        [Demo]
        public ActionResult Local_Data_Binding_TagHelper()
        {
            ViewBag.inlineTagHelperDefault = TagHelperDefaultInlineData();
            ViewBag.inlineTagHelper = TagHelperInlineData();
            return View();
        }

        private IEnumerable<TreeViewItemBase> TagHelperDefaultInlineData()
        {
            List<TreeViewItemBase> inlineDefault = new List<TreeViewItemBase>
                {
                    new TreeViewItemBase
                    {
                        Text = "Furniture",
                        Items = new List<TreeViewItemBase>
                        {
                            new TreeViewItemBase()
                            {
                                Text = "Tables & Chairs"
                            },
                            new TreeViewItemBase
                            {
                                 Text = "Sofas"
                            },
                            new TreeViewItemBase
                            {
                                 Text = "Occasional Furniture"
                            }
                        }
                    },
                    new TreeViewItemBase
                    {
                        Text = "Decor",
                        Items = new List<TreeViewItemBase>
                        {
                            new TreeViewItemBase()
                            {
                                Text = "Bed Linen"
                            },
                            new TreeViewItemBase
                            {
                                 Text = "Curtains & Blinds"
                            },
                            new TreeViewItemBase
                            {
                                 Text = "Carpets"
                            }
                        }
                    }
                };

            return inlineDefault;
        }

        private IEnumerable<CategoryItem> TagHelperInlineData()
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
};
