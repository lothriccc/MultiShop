﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MutliShop.IdentityServer
{
	public static class Config
	{
		public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
		{
			new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
			new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
			new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
			new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
			new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
			new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
			new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
			new ApiResource("ResourceImages"){Scopes={"ImagesFullPermission"}},
			new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
			new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
		};
		public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
		{
			new IdentityResources.OpenId(),
			new IdentityResources.Email(),
			new IdentityResources.Profile()
		};

		public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
		{
			new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
			new ApiScope("DiscountFullPermission","Full authority for discount operations"),
			new ApiScope("OrderFullPermission","Full authority for order operations"),
			new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
			new ApiScope("CargoFullPermission","Reading authority for cargo operations"),
			new ApiScope("BasketFullPermission","Reading authority for basket operations"),
			new ApiScope("CommentFullPermission","Reading authority for comment operations"),
			new ApiScope("PaymentFullPermission","Reading authority for payment operations"),
			new ApiScope("ImagesFullPermission","Reading authority for images operations"),
			new ApiScope("OcelotFullPermission","Reading authority for ocelot operations"),
			new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

		};

		public static IEnumerable<Client> Clients => new Client[]
		{
            //Visitor
            new Client
			{
				ClientId="MultishopVisitorId",
				ClientName="Multi Shop Visitor User",
				AllowedGrantTypes=GrantTypes.ClientCredentials,
				ClientSecrets={new Secret("multishopsecret".Sha256()) },
				AllowedScopes={ "CatalogReadPermission" , "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImagesFullPermission", "CatalogFullPermission", 
					IdentityServerConstants.LocalApi.ScopeName }
			},
            //Manager
            new Client
			{
				ClientId="MultiShopManagerId",
				ClientName="Multi Shop Manager User",
				AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,	
				ClientSecrets={new Secret("multishopsecret".Sha256()) },
				AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "BasketFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission" , "ImagesFullPermission" , "DiscountFullPermission","OrderFullPermission",

                    IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile}

            },
            //Admin
			new Client
			{
				ClientId="MultiShopAdminId",
				ClientName="Multi Shop Admin User",
				AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
				ClientSecrets={new Secret("multishopsecret".Sha256()) },
				AllowedScopes={ "CatalogFullPermission" , "DiscountFullPermission", "OrderFullPermission", "CatalogReadPermission","CargoFullPermission","BasketFullPermission","OcelotFullPermission","CommentFullPermission", "PaymentFullPermission","ImagesFullPermission",

                IdentityServerConstants.LocalApi.ScopeName,
				IdentityServerConstants.StandardScopes.Email,
				IdentityServerConstants.StandardScopes.OpenId,
				IdentityServerConstants.StandardScopes.Profile
				},
				AccessTokenLifetime=600

			},
		};
	}
}