# Kinde Starter Kit - ASP.NET Core based API

The Kinde Starter Kit for ASP.NET Core based APIs.

[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](https://makeapullrequest.com) [![Kinde Docs](https://img.shields.io/badge/Kinde-Docs-eee?style=flat-square)](https://kinde.com/docs/developer-tools) [![Kinde Community](https://img.shields.io/badge/Kinde-Community-eee?style=flat-square)](https://thekindecommunity.slack.com)

## Register an account on Kinde

To get started set up an account on [Kinde](https://app.kinde.com/register). You should create a front-end/mobile application in Kinde with at least one associated API.

## Setup your local environment

Clone this repo.

Modify `appsettings.json`, replace `<your-domain>` with your Kinde domain and `<your-audience>` with the audience associated with your API in Kinde.

## Setup Swagger UI

If you would like to obtain acccess tokens via the Swagger UI for development you will be redirected to Kinde to authenticate. After you have logged in or registered you will be redirected back to your local Swagger UI.

You need to allow the callback of Swagger UI in Kinde, on the `Settings -> Applications -> Frontend app` page add `https://localhost:7179/swagger/oauth2-redirect.html` to `Allowed callback URLs`.

> Important! This is required to successfully log in to your app.

Modify `appsettings.Development.json` and replace `<frontend-app-client-id>` with the client ID for your application in Kinde.

## Contributing

Please refer to Kinde’s [contributing guidelines](https://github.com/kinde-oss/.github/blob/489e2ca9c3307c2b2e098a885e22f2239116394a/CONTRIBUTING.md).

## License

By contributing to Kinde, you agree that your contributions will be licensed under its MIT License.
