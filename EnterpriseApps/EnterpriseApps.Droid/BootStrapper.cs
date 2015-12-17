﻿using System;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using EnterpriseApps.Portable.Service;
using GalaSoft.MvvmLight.Views;
using EnterpriseApps.Portable.ViewModel;

namespace EnterpriseApps.Droid
{
	public static class BootStrapper
	{
		private static bool _isInistialized = false;

		public static void Init ()
		{

			if (_isInistialized)
				return;

			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			// Register Services
			SimpleIoc.Default.Register<IHttpService>(() => 
				{
					return new HttpService("http://api.randomuser.me/");
				});
			SimpleIoc.Default.Register<IMappingService, MappingService>();
			SimpleIoc.Default.Register<EnterpriseApps.Portable.Service.IResourceService, ResourceService>();
			SimpleIoc.Default.Register<IDialogService, DialogService>();
			SimpleIoc.Default.Register<IUserRepository, UserRepository>();
			SimpleIoc.Default.Register<ImageService> ();

			// Register ViewModels
			SimpleIoc.Default.Register<UsersViewModel>();
			SimpleIoc.Default.Register<UserViewModel>();
			_isInistialized = true;
		}
	}
}

