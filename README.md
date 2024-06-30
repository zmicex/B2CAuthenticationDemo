# Azure B2C Authentication and Claims Enrichment Demo

This repository is created to reproduce the issue I'm encountering with Azure AD B2C and `IClaimsTransformation`. I'm using `IClaimsTransformation` to enrich user claims. Currently, I'm facing the following error:

"AADSTS50049: Unknown or invalid instance."

This error occurs when I try to generate a token to call my API, which provides necessary data to enrich the user's claim.

I've posted about this issue on Stack Overflow as well:

1. [Issue with token generation in ASP.NET Core 8 using Azure AD B2C](https://stackoverflow.com/questions/78685757/issue-with-token-generation-in-asp-net-core-8-using-azure-ad-b2c-error-aadsts50)
2. [Error AADSTS50049: Unknown or invalid instance in ASP.NET Core 8 MVC with Azure AD B2C](https://stackoverflow.com/questions/78683654/error-aadsts50049-unknown-or-invalid-instance-in-asp-net-core-8-mvc-with-azur)

## Prerequisites

- **.NET Core 8 SDK** installed
- **Azure AD B2C instance** configured
- **Visual Studio 2022** or later

## Setup Instructions

1. **Clone the repository:**

   ```bash
   git clone https://github.com/zmicex/azure-b2c-claims-enrichment-demo.git
   cd azure-b2c-claims-enrichment-demo
2. **Configure Azure AD B2C:**

   - Follow the [official Microsoft instructions](https://learn.microsoft.com/en-us/azure/active-directory-b2c/tutorial-create-tenant) to create an Azure AD B2C tenant.
   
   - Set up policies and applications as required

## Current Issues

The main issue revolves around using `IClaimsTransformation` to enrich user claims and encountering `AADSTS50049: Unknown or invalid instance` during token generation for API calls. This repository serves as a sandbox to replicate and resolve this issue.

## Running the Application

- Run the application using Visual Studio or `dotnet run` from the command line.
- Navigate to the specified URL in your browser to observe the behavior.

## Troubleshooting

### Known Errors

- **AADSTS50049**: Ensure that the Azure AD B2C instance is correctly configured.

## Contributions

If you have encountered similar issues or have insights to share, contributions are welcome through pull requests or by reporting issues.
