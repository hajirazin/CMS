Feature: HomeControllerTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@RazinMemon
Scenario: Get Products
	When I call Index of Home
	Then It Should return "Products" View
	And Its Model type should be "System.Collections.Generic.List`1[[Ramesoft.Cms.Common.Models.ProductModel, Ramesoft.Cms.Common, Version=2.0.5019.40602, Culture=neutral, PublicKeyToken=null]]"

@RazinMemon
Scenario: Get Logs
	When I call Logs of Home
	Then It Should return "Logs" View
	And Its Model type should be "System.Collections.Generic.List`1[[Ramesoft.Cms.Common.Entity.Log, Ramesoft.Cms.Common, Version=2.0.5019.40602, Culture=neutral, PublicKeyToken=null]]"