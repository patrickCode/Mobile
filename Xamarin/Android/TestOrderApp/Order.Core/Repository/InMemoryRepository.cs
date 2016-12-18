using System.Linq;
using Order.Core.Models;
using System.Collections.Generic;

namespace Order.Core.Repository
{
    public class InMemoryRepository: IRepository
    {
        private static List<ProductGroup> _productGroups = new List<ProductGroup>
        {
            new ProductGroup
            {
                Id = 1,
                ImagePath = "",
                Title = "Xamarin",
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Abstract = "First Product In Standard",
                        IsAvailable = true,
                        IsFavorite = true,
                        Name = "Xamarin Android",
                        ShortDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum et Malorum' (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from a line in section 1.10.32.",
                        Price = 8162.98M,
                        ImagePath = "http://www.siyawoman.com/wp-content/uploads/2015/09/product.png"
                    },
                    new Product
                    {
                        Id = 2,
                        Abstract = "Second Product In Standard",
                        IsAvailable = true,
                        IsFavorite = true,
                        Name = "Xamarin Forms",
                        ShortDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum et Malorum' (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from a line in section 1.10.32.",
                        Price = 1162.98M,
                        ImagePath = "http://www.shmula.com/wp-content/uploads/2007/02/interface-is-product-ux-ui.jpg"
                    },
                    new Product
                    {
                        Id = 3,
                        Abstract = "Third Product In Standard",
                        IsAvailable = true,
                        IsFavorite = false,
                        Name = "Xamarin IOS",
                        ShortDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum et Malorum' (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from a line in section 1.10.32.",
                        Price = 198162.98M,
                        ImagePath = "http://bsccongress.com/wp-content/uploads/2016/06/street-sign-new-product-signage-clip-art.png"
                    },
                    new Product
                    {
                        Id = 4,
                        Abstract = "Fourth Product In Standard",
                        IsAvailable = true,
                        IsFavorite = false,
                        Name = "Xamarin Web View",
                        ShortDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum et Malorum' (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from a line in section 1.10.32.",
                        Price = 1462.98M,
                        ImagePath = "http://images.clipartpanda.com/product-clipart-can-stock-photo_csp9559306.jpg"
                    }
                }
            },
            new ProductGroup
            {
                Id = 2,
                Title = "Ionic",
                ImagePath = "",
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 7,
                        Name = "Angular",
                        Abstract = "First Product in Ionic",
                        ImagePath = "http://cdn2.hubspot.net/hubfs/51294/new_product_manager_lessons.jpg",
                        IsAvailable = true,
                        IsFavorite = false,
                        Price = 12331.9M,
                        ShortDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum et Malorum' (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from a line in section 1.10.32."
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Angular 2",
                        Abstract = "Second Product in Ionic",
                        ImagePath = "http://kingofwallpapers.com/product/product-002.jpg",
                        IsAvailable = true,
                        IsFavorite = false,
                        Price = 17321.9M,
                        ShortDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum et Malorum' (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from a line in section 1.10.32."
                    },
                    new Product
                    {
                        Id = 10,
                        Name = "Cordova",
                        Abstract = "Third Product in Ionic",
                        ImagePath = "https://media.ibisworld.com/wp-content/uploads/2014/02/Products-Services1.jpg",
                        IsAvailable = true,
                        IsFavorite = false,
                        Price = 17321.9M,
                        ShortDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 'de Finibus Bonorum et Malorum' (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, 'Lorem ipsum dolor sit amet..', comes from a line in section 1.10.32."
                    }
                }
            }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return _productGroups.SelectMany(group => group.Products);
        }

        public Product GetById (int Id)
        {
            return _productGroups.SelectMany(group => group.Products).FirstOrDefault(prod => prod.Id == Id);
        }

        public IEnumerable<ProductGroup> GetProductGroups()
        {
            return _productGroups;
        }

        public ProductGroup GetProductGroup(int id)
        {
            return _productGroups.FirstOrDefault(group => group.Id == id);
        }

        public IEnumerable<Product> GetFavouriteProducts()
        {
            return _productGroups.SelectMany(group => group.Products).Where(prod => prod.IsFavorite);
        }
    }
}