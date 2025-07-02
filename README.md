# 🚀 DevFlexiConnect – Automated CI/CD Pipeline for .NET API on Azure

![Flexiconnect-API](https://github.com/user-attachments/assets/d6938cdc-7e78-4548-bad4-7ad0ae6ec7dc)


**DevFlexiConnect** is a robust, production-ready CI/CD pipeline designed for .NET 8.0 APIs using GitHub Actions and Azure Web App. It supports seamless deployment from development to production environments, enforces code reviews, and boosts engineering productivity through automation.

---

## 🌟 Features

✅ Automated build and deployment of .NET API to Azure Web App  
✅ CI pipeline triggered on push to `dev` branch  
✅ Automated Pull Request (PR) creation from `feature/*` branches  
✅ Auto-merge PRs after approval and mergeability checks  
✅ Captures build artifacts and deployment logs  
✅ Secure integration using GitHub Secrets  
✅ Status badges for CI visibility  
✅ Modular and maintainable YAML workflows

---

## 🛠️ Tech Stack & Tools

| Tool/Tech       | Purpose                                |
|-----------------|----------------------------------------|
| **.NET 8.0**    | Backend API framework                  |
| **Azure App Service** | Hosting platform for API deployment |
| **GitHub Actions** | CI/CD orchestration                  |
| **PowerShell / Bash** | Scripting tasks in workflows       |
| **curl + jq**   | API interaction for PR and approval checks |
| **GitHub Secrets** | Secure credentials management        |

---

## 📦 Repository Structure

```bash
.
├── .github/
│   └── workflows/
│       ├── deployapi.yml        # CI/CD pipeline for dev
│       └── autopr.yml           # Automated PR + auto-merge
├── src/                         # Your .NET API source code
├── assets/                      # Diagrams and screenshots
└── README.md                    # Project documentation
````

---

## 🔁 Workflow Overview

### 📤 `deployapi.yml` – Deploy API to Azure

> Triggered on: `push` to `dev`

**Steps:**

1. Checkout code
2. Setup .NET SDK (v8.0)
3. Restore dependencies
4. Build and publish API
5. Upload build artifacts
6. Save and upload build logs
7. Deploy to Azure Web App using a publish profile

### 🔁 `autopr.yml` – Automate PR Creation & Review

> Triggered on: `push` to `feature/*`

**Steps:**

1. Automatically creates PR to `dev` on any feature push
2. Waits for **code owner approval** for up to 24 hours
3. Merges PR if approval and mergeability conditions are satisfied
4. Uses squash merge strategy

---

## 🖼️ Visual Pipeline Overview

### Feature to Dev Flow

![branch_flow](https://github.com/user-attachments/assets/9306695d-5b3d-4a8e-877c-6e1d59cd3d95)


### CI/CD Deployment Stages

![ci-cd](https://github.com/user-attachments/assets/e1666f1b-27ec-4d04-8794-9f0b45ff83fe)


---

## ⚙️ Setup Instructions

### 1. Prerequisites

* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Azure Web App (named `devflexiconnect`)
* GitHub repository with these secrets:

  * `AZURE_PUBLISH_PROFILE` – Exported from Azure App Service
  * `RAJ_TOKEN` – GitHub token with `repo` permissions

### 2. Local Setup

```bash
git clone https://github.com/OWNER/REPO.git
cd REPO
dotnet restore
dotnet build
dotnet run
```

---

## 📡 How CI/CD Works

* Push to `dev` → triggers `deployapi.yml` to build & deploy to Azure
* Push to `feature/*` → triggers `autopr.yml`, creates PR to `dev`
* PR waits for approval → auto-merges on code-owner approval & successful checks
* Deployment artifacts are stored for traceability

---

## 🤝 Contributing

We welcome contributions!

1. Fork this repo
2. Create a branch: `git checkout -b feature/your-feature`
3. Commit and push your code
4. Your PR will be auto-created
5. A code owner must approve it to merge

---

## 🛡️ Security Practices

* Credentials managed using GitHub encrypted secrets
* Azure publish profile never stored in code
* PR auto-merge is protected by approval requirements
* Build and deployment logs are uploaded as artifacts

---

## 📬 Contact

For questions, suggestions, or issues, please [open an issue](https://github.com/OWNER/REPO/issues) or contact the maintainer.

LinkedIn: (https://www.linkedin.com/in/muthuarun/)
GitHub:   (https://github.com/Muthuarun1617)

---

## 📚 Resources & References

* [GitHub Actions Documentation](https://docs.github.com/actions)
* [Deploying to Azure Web App](https://learn.microsoft.com/en-us/azure/app-service/deploy-github-actions)
* [Creating Azure Publish Profile](https://learn.microsoft.com/en-us/visualstudio/deployment/import-publish-settings)

---

```

---

