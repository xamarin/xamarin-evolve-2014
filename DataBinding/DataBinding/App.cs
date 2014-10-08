using System;
using Xamarin.Forms;
using DataBinding.Pages;
using AutoMapper;
using DataBinding.Common;
using DataBinding.ViewModels;

namespace DataBinding
{
	public class App
	{
		public static void InitMapping ()
		{
			Mapper.CreateMap<ComicBook, ComicBookViewModel>();
		}

		public static Page GetMainPage ()
		{	
			return new NavigationPage (new MenuPage ()){
				BarBackgroundColor = UIHelper.BarBackgroundColor,
				BarTextColor = UIHelper.TintColor
			};
		}
	}
}

