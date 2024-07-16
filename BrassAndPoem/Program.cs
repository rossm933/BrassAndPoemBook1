//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Numerics;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Trumpet",
        Price = 99.99m,
        ProductTypeId = 1,
    },

    new Product()
    {
         Name = "French Horn",
        Price = 160.99m,
        ProductTypeId = 1,
    },

     new Product()
    {
        Name = "Trombone",
        Price = 213.50m,
        ProductTypeId = 1,
    },

     new Product()
    {
        Name = "The Road Not Taken",
        Price = 22.49m,
        ProductTypeId = 2,
    },

     new Product()
    {
        Name = "The Raven",
        Price = 34.59m,
        ProductTypeId = 2,
    }

};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass",
        Id = 1
    },
    new ProductType()
    {
        Title = "Poems",
        Id = 2
    }
};

//put your greeting here
string greeting = @"Welcome to BrassAndPoem! How can we help you today?";
Console.WriteLine(greeting);

//implement your loop here
string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Clear();
        DisplayAllProducts(products, productTypes);
    }
    else if (choice == "2")
    {
        Console.Clear();
        DeleteProduct(products, productTypes);
    }
    else if (choice == "3")
    {
        Console.Clear();
        AddProduct(products, productTypes);
    }
    else if (choice == "4")
    {
        Console.Clear();
        UpdateProduct(products, productTypes);
    }
    else if (choice == "5")
    {
        Console.WriteLine("Goodbye!");
    }
}
void DisplayMenu()
{
    Console.WriteLine(@"Please choose an option:
        1. Display all products
        2. Delete a product
        3. Add a new product
        4. Update product properties
        5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {

        string title = productTypes.First(p => p.Id == products[i].ProductTypeId).Title;

        Console.WriteLine($"{i}. {products[i].Name} Price: {products[i].Price:C} Type: {title}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    string choice = null;

    while (choice != "0")
    {
        try
        {
            Console.WriteLine("0. Goodbye");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name}");

            }
            choice = Console.ReadLine();
            products.RemoveAt(Int32.Parse(choice) - 1);
        }
        catch
        {
            break;
        }

    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("To add a product, please enter product name");

    string responseName = Console.ReadLine();

    Console.WriteLine("Please enter the product price");

    decimal responsePrice = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine(@"Please select a product type ID:
    1. Brass
    2. Poems");

    int responseID = int.Parse(Console.ReadLine());

    Product newProduct = new Product
    {
        Name = responseName,
        Price = responsePrice,
        ProductTypeId = responseID

    };

    products.Add(newProduct);

    Console.WriteLine($"You added: {newProduct.Name}, which costs {newProduct.Price} dollars");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Choose which product to update: ");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    if (int.TryParse(Console.ReadLine(), out int choiceIndex))
    {
        Product selectedProduct = products[choiceIndex - 1];
        Console.WriteLine($"You chose {selectedProduct.Name}.");

        Console.WriteLine("Enter new name: (press Enter again if no change required)");
        string updatedName = Console.ReadLine();
        if (!string.IsNullOrEmpty(updatedName))
        {
            selectedProduct.Name = updatedName;
        }

        Console.WriteLine("Enter new price: (press Enter again if no change required)");
        string newPrice = Console.ReadLine();
        if (!string.IsNullOrEmpty(newPrice) && decimal.TryParse(newPrice, out decimal updatedPrice))
        {
            selectedProduct.Price = updatedPrice;
        }

        Console.WriteLine("Select new product type: (press Enter if no change required)");
        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
        }
        string response = Console.ReadLine();
        if (!string.IsNullOrEmpty(response) && int.TryParse(response, out int newType))
        {
            selectedProduct.ProductTypeId = productTypes[newType - 1].Id;
        }

        Console.WriteLine($"{selectedProduct.Name} has been successfully updated!");
    }
    else
    {
        Console.WriteLine("There was an error updating this product.");
    }
}

// don't move or change this!
public partial class Program { }