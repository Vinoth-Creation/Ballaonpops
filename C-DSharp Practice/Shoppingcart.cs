using System;
class Product
{
	public string productName;
	public string productType;
	public float productPrice;
	public int productQty;
	public float totalPrice;
	
	public Product(string name, string type, float price, int qty)
	{
		productName = name;
		productPrice = price;
		productQty = qty;
		productType = type;
		totalPrice = productPrice*productQty;
	}
	public void ShowTotalPrice()
	{
		Console.WriteLine($"Total Price of the Order : {totalPrice}");
	}
}
class CategoryDiscount:Product
{
	public float discountPrice;
	public float discountPercentage;
	public CategoryDiscount(string name, string type, float price, int qty):base(name, type, price, qty)
	{
	}
	public void ShowDiscountPrice()
	{
		if(productType.ToLower() == "furnitures")
		{
			discountPercentage = 15;
			discountPrice = totalPrice * (discountPercentage/100);
			Console.WriteLine($"Discount Amount is : {discountPrice}");
		}
		else if(productType.ToLower() == "clothings")
		{
			discountPercentage = 10;
			discountPrice = totalPrice * (discountPercentage/100);
			Console.WriteLine($"Discount Amount is : {discountPrice}");
		}
		else if(productType.ToLower() == "toys")
		{
			discountPercentage = 8;
			discountPrice = totalPrice * (discountPercentage/100);
			Console.WriteLine($"Discount Amount is : {discountPrice}");
		}
		else if(productType.ToLower() == "others")
		{
			discountPercentage = 2;
			discountPrice = totalPrice * (discountPercentage/100);
			Console.WriteLine($"Discount Amount is : {discountPrice}");
		}
	}
}
class FinalPrice:CategoryDiscount
{
	public float finalPurchasePrice;
	public FinalPrice(string name, string type, float price, int qty):base(name,type,price,qty)
	{
	}
	public void ShowFinalPrice()
	{
		finalPurchasePrice = (totalPrice - discountPrice);
		Console.WriteLine($"Final Price is : {finalPurchasePrice}");
	}
}
class Program
{
	static void Main()
	{
		Console.WriteLine("==== Online Shopping Cart ====");
		string productType = "";
		bool validType = false;
		while (!validType)
		{
		Console.WriteLine("Product Types : furnitures / clothings / toys / others ");
		Console.Write("Enter Product Type : ");
		productType = Console.ReadLine().ToLower();
			if(productType == "furnitures" || productType == "clothings" || productType == "toys" || productType == "others")
			{
				validType = true;
			}
			else
			{
				Console.WriteLine("Invalid Entry., Please Enter Valid Input. Anyone of the following (furnitures / clothings / toys / others)");
			}
		}
		Console.Write("Enter Product Name : ");
		string productName = Console.ReadLine();
		float productPrice = 0;
		bool validPrice = false;
		while(!validPrice)
		{
			Console.Write("Enter Product Price : ");
			string input = Console.ReadLine();
			if(float.TryParse(input, out productPrice))
			{
				   validPrice = true;
			}
			else
			{
				Console.WriteLine("Invalid Number. Please Enter digits only.");
			}
		}
		int productQty = 0;
		bool validQty = false;
		while(!validQty)
		{
			Console.Write("Enter Product Qty : ");
			string input = Console.ReadLine();
			if(int.TryParse(input, out productQty))
			{
				validQty = true;
			}
			else
			{
				Console.WriteLine("Invalid Number. Please Enter digits only.");
			}
		}
		FinalPrice item = new FinalPrice(productName, productType, productPrice, productQty);
		item.ShowTotalPrice();
		item.ShowDiscountPrice();
		item.ShowFinalPrice();
	}
}