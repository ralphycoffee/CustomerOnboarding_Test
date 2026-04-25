# React + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Oxc](https://oxc.rs)
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/)

## React Compiler

The React Compiler is not enabled on this template because of its impact on dev & build performances. To add it, see [this documentation](https://react.dev/learn/react-compiler/installation).

## Expanding the ESLint configuration

If you are developing a production application, we recommend using TypeScript with type-aware lint rules enabled. Check out the [TS template](https://github.com/vitejs/vite/tree/main/packages/create-vite/template-react-ts) for information on how to integrate TypeScript and [`typescript-eslint`](https://typescript-eslint.io) in your project.


Backend:

Create customer
Get customer by ID
Get all customers
Input validation (service layer)
SQLite database auto-created (No external database setup required (SQLite used))
Dependency Injection implemented
Unit tests using xUnit + Moq
Frontend:
Customer onboarding form
Signature capture using HTML Canvas
REST API integration
Basic validation
Success / error feedback

- Run Backend
Open Visual Studio or navigate using Command Prompt:
cd src/CustomerOnboardingSystem.Api
Restore dependencies:
dotnet restore
Run the API:
dotnet run
The API will run at:
https://localhost:7109
or
https://localhost:5125
SQLite database (customers.db) will be created automatically on first run.
- Run Frontend
Open a new terminal and navigate:
cd frontend
Install dependencies:
npm install
Run the React app:
npm run dev
Open in browser:
http://localhost:5173

Author:
Ralph Randie C. Del Socorro