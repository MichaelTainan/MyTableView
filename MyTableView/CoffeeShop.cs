using System;
using System.Linq;
using System.Collections.Generic;

namespace MyTableView
{
	public class CoffeeShop
	{
		public CoffeeShop ()
		{
		}


		public string Name { get; set;}
		public string PhoneNumber { get; set;}
	}

	public class CoffeeShopWorker 
	{
		public List<CoffeeShop> ReadCoffeeShops (){

			var results = new List<CoffeeShop> ();

			results.Add (new CoffeeShop{ Name = @"統一星巴克 三多門市", PhoneNumber = @"073384586" });

			results.Add (new CoffeeShop{ Name = @"統一星巴克 高雄遠百門市", PhoneNumber = @"075360501"  });

			return results;
		}

	}
}

