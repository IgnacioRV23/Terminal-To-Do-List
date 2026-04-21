# 📝 Terminal To-Do List — C# Console CRUD App

![C#](https://img.shields.io/badge/Language-C%23-239120?style=flat&logo=csharp)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)
![Platform](https://img.shields.io/badge/Platform-Console-lightgrey?style=flat)
![NuGet](https://img.shields.io/badge/NuGet-ConsoleTableExt_3.3.0-004880?style=flat&logo=nuget)

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Project Structure](#-project-structure)
- [Prerequisites](#-prerequisites)
- [How to Run (Visual Studio)](#-how-to-run-visual-studio)
- [Menu Reference](#-menu-reference)
- [Usage Examples & Test Cases](#-usage-examples--test-cases)
- [Task Data Model](#-task-data-model)

---

## 🌐 Overview

**Terminal To-Do List** is a lightweight, fully interactive **CRUD console application** built with **C# and .NET 8**. It allows you to manage your tasks entirely from the terminal — no graphical interface, no database, no server required.

The application features:
- A stylized **ASCII art welcome screen** rendered in color
- A **menu-driven interface** for all operations
- Full **CRUD support**: Create, Read, Update, and Delete tasks
- **Progress tracking** per task (To Do → In Progress → Done)
- **Priority levels** with color-coded messages (High 🔴 / Medium 🟡 / Low 🟢)
- Automatic **timestamps** for task creation and last update
- Tabular output powered by the [`ConsoleTableExt`](https://github.com/minhhungit/ConsoleTableExt) NuGet package

> **Important:** This is a pure console application — there are no HTTP endpoints, no REST API, and no web server. All interaction happens through keyboard input in the terminal.

---

## 📁 Project Structure

```
Terminal-To-Do-List/
│
├── Program.cs                           # Entry point — main menu loop
├── Task.cs                              # Core CRUD logic for task management
├── TextArt.cs                           # ASCII art banners & colored console helpers
├── Terminal - To Do List - CSHARP.csproj  # Project file (.NET 8, ConsoleTableExt dep)
├── Terminal - To Do List - CSHARP.sln     # Visual Studio solution file
└── .gitignore
```

| File | Responsibility |
|------|---------------|
| `Program.cs` | Renders the welcome screen, loops the main menu, routes user input |
| `Task.cs` | Contains `AddTask`, `UpdateTask`, `UpdateProgress`, `DeleteTask`, `ReadTasks` |
| `TextArt.cs` | ASCII banners (`Welcome`, `Bye`) and color helpers (`SuccessMsg`, `ErrorMsg`, `WarningMsg`, `QuestionMsg`) |

---

## ✅ Prerequisites

Before running the project, make sure you have the following installed:

| Tool | Minimum Version | Download |
|------|----------------|---------|
| **Visual Studio** | 2022 (v17+) | [visualstudio.microsoft.com](https://visualstudio.microsoft.com/) |
| **.NET SDK** | 8.0 | [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0) |
| **Git** | Any | [git-scm.com](https://git-scm.com/) |

> You can verify your .NET version by running `dotnet --version` in a terminal. It should return `8.x.x`.

---

## ▶️ How to Run (Visual Studio)

### Step 1 — Clone the repository

```bash
git clone https://github.com/IgnacioRV23/Terminal-To-Do-List.git
cd Terminal-To-Do-List
```

### Step 2 — Open the solution in Visual Studio

1. Launch **Visual Studio 2022**.
2. Click **"Open a project or solution"** from the start screen.
3. Navigate to the cloned folder and select the file:
   ```
   Terminal - To Do List - CSHARP.sln
   ```
4. Visual Studio will load the solution automatically.

### Step 3 — Restore NuGet packages

Visual Studio usually restores packages automatically on load. If not:

- Go to **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**
- Click **"Restore"**, or right-click the project in Solution Explorer and select **"Restore NuGet Packages"**

The only external dependency is:

```xml
<PackageReference Include="ConsoleTableExt" Version="3.3.0" />
```

### Step 4 — Configure the startup project

In **Solution Explorer**, right-click on `Terminal - To Do List - CSHARP` and select **"Set as Startup Project"**.

### Step 5 — Run the application

Press **`F5`** (with debugging) or **`Ctrl + F5`** (without debugging) to launch the application.

> 💡 **Tip:** Use `Ctrl + F5` so the console window stays open after execution completes.

A terminal window will open displaying the ASCII art welcome banner, followed by the main menu.

### Alternative — Run via .NET CLI

If you prefer the command line:

```bash
dotnet restore
dotnet run --project "Terminal - To Do List - CSHARP.csproj"
```

---

## 🗂️ Menu Reference

Once the application starts, you will see the following menu:

```
+------------------------+
|       Main Menu        |
|   Add Task      [A]    |
|   Update Task   [U]    |
|   Update Progress [P]  |
|   Delete Task   [D]    |
|   List Tasks    [R]    |
|   Close System  [X]    |
+------------------------+
```

Type the letter shown in brackets and press `Enter` to execute the corresponding action. Input is **case-insensitive** (`a` and `A` both work).

---

## 🧪 Usage Examples & Test Cases

The following scenarios walk you through every feature of the application from a fresh start.

---

### ✅ Test Case 1 — Add a Task (press `A`)

**Prompt sequence:**

```
Task name:
> Buy groceries

Task description:
> Milk, eggs, bread, and coffee

Task priority
High [H]
Medium [M]
Low [L]
> L
```

**Expected output:**

```
Task created successfully.
```

A new task is added to the in-memory list with:
- A generated ID (e.g., `1010`)
- Priority: `Low`
- Progress: `To do`
- Created Date: current timestamp

---

### ✅ Test Case 2 — Add a Second Task (press `A`)

```
Task name:
> Fix login bug

Task description:
> Users cannot log in after password reset

Task priority
> H
```

**Expected output:**

```
Task created successfully.
```

A second task is added with ID `1020`, Priority `High`, Progress `To do`.

---

### ✅ Test Case 3 — List All Tasks (press `R`)

**Expected output** (rendered as a table):

```
╔══════╦════════════════╦══════════════════════════════════╦══════════╦══════════╦════════════════════╦══════════════╗
║  ID  ║ Name           ║ Description                      ║ Priority ║ Progress ║ Created Date       ║ Updated Date ║
╠══════╬════════════════╬══════════════════════════════════╬══════════╬══════════╬════════════════════╬══════════════╣
║ 1010 ║ Buy groceries  ║ Milk, eggs, bread, and coffee    ║ Low      ║ To do    ║ 04/21/2025 10:30AM ║              ║
║ 1020 ║ Fix login bug  ║ Users cannot log in after reset  ║ High     ║ To do    ║ 04/21/2025 10:31AM ║              ║
╚══════╩════════════════╩══════════════════════════════════╩══════════╩══════════╩════════════════════╩══════════════╝
```

Press any key to return to the menu.

---

### ✅ Test Case 4 — Update a Task's Info (press `U`)

You will first see the task list, then be prompted:

```
Enter the ID of the task to be updated:
> 1020

Enter update task name:
> Fix authentication bug

Enter update task description:
> Users cannot log in after password reset — investigate JWT expiry

Enter update task priority
High [H]  /  Medium [M]  /  Low [L]
> M
```

**Expected output:**

```
Information updated successfully.
```

The task with ID `1020` now has updated name, description, priority `Medium`, and a new `Updated Date` timestamp.

---

### ✅ Test Case 5 — Update Progress (press `P`)

```
Enter the ID of the task to be updated:
> 1010

Enter new progress task:
To do [T]
In Progress [P]
Done [D]
> P
```

**Expected output:**

```
Information updated successfully.
```

Task `1010` now shows `In Progress` in the Progress column.

---

### ✅ Test Case 6 — Delete a Task (press `D`)

```
Enter the ID of the task to be deleted:
> 1010

Are you sure you want to delete task 1010?
Yes [Y]
No [N]
> Y
```

**Expected output:**

```
Information deleted successfully.
```

Task `1010` is permanently removed from the list.

**If you choose `N`:**

```
Information not deleted.
```

---

### ✅ Test Case 7 — Error Handling

**Listing tasks when none exist:**

```
> R
Tasks not found. :(
```

**Entering a non-existent ID:**

```
Enter the ID of the task to be updated:
> 9999

Task ID 9999 not found. :(
```

**Entering an invalid priority repeatedly:**

```
Task priority
> Z        ← invalid, loop repeats
Task priority
> X        ← invalid, loop repeats
Task priority
> H        ← accepted
```

---

### ✅ Test Case 8 — Close the Application (press `X`)

The application displays the ASCII "Goodbye" banner and exits cleanly.

---

## 📦 Task Data Model

Each task is stored as a `List<object>` with the following fields in order:

| Index | Field | Type | Example |
|-------|-------|------|---------|
| 0 | ID | `int` | `1010` |
| 1 | Name | `string` | `"Fix login bug"` |
| 2 | Description | `string` | `"Investigate JWT expiry"` |
| 3 | Priority | `string` | `"High"` / `"Medium"` / `"Low"` |
| 4 | Progress | `string` | `"To do"` / `"In Progress"` / `"Done"` |
| 5 | Created Date | `string` | `"04/21/2025 10:30AM"` |
| 6 | Updated Date | `string` | `"04/21/2025 11:00AM"` or `""` |

> **Note:** All data is stored **in memory** only. Tasks are lost when the application closes. There is no database or file persistence.

---

---

<br/>

# 📝 Terminal To-Do List — Aplicación de Consola CRUD en C#

![C#](https://img.shields.io/badge/Lenguaje-C%23-239120?style=flat&logo=csharp)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)
![Plataforma](https://img.shields.io/badge/Plataforma-Consola-lightgrey?style=flat)
![NuGet](https://img.shields.io/badge/NuGet-ConsoleTableExt_3.3.0-004880?style=flat&logo=nuget)

---

## 📋 Tabla de Contenidos

- [Descripción General](#-descripción-general)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Prerrequisitos](#-prerrequisitos)
- [Cómo Ejecutar (Visual Studio)](#-cómo-ejecutar-visual-studio)
- [Referencia del Menú](#-referencia-del-menú)
- [Casos de Uso y Ejemplos de Prueba](#-casos-de-uso-y-ejemplos-de-prueba)
- [Modelo de Datos de Tarea](#-modelo-de-datos-de-tarea)

---

## 🌐 Descripción General

**Terminal To-Do List** es una **aplicación de consola CRUD** interactiva, construida con **C# y .NET 8**. Permite gestionar tareas completamente desde la terminal, sin necesidad de interfaz gráfica, base de datos ni servidor.

La aplicación incluye:
- Una **pantalla de bienvenida en ASCII art** con colores
- Una **interfaz basada en menú** para todas las operaciones
- Soporte **CRUD completo**: Crear, Leer, Actualizar y Eliminar tareas
- **Seguimiento de progreso** por tarea (Por hacer → En progreso → Hecho)
- **Niveles de prioridad** con mensajes en color (Alta 🔴 / Media 🟡 / Baja 🟢)
- **Marcas de tiempo** automáticas de creación y última actualización
- Salida en formato de tabla gracias al paquete NuGet [`ConsoleTableExt`](https://github.com/minhhungit/ConsoleTableExt)

> **Importante:** Esta es una aplicación de consola pura — no existen endpoints HTTP, REST API ni servidor web. Toda la interacción se realiza mediante teclado en la terminal.

---

## 📁 Estructura del Proyecto

```
Terminal-To-Do-List/
│
├── Program.cs                           # Punto de entrada — bucle del menú principal
├── Task.cs                              # Lógica CRUD principal para la gestión de tareas
├── TextArt.cs                           # Banners ASCII y helpers de consola con color
├── Terminal - To Do List - CSHARP.csproj  # Archivo de proyecto (.NET 8, dependencia ConsoleTableExt)
├── Terminal - To Do List - CSHARP.sln     # Archivo de solución de Visual Studio
└── .gitignore
```

| Archivo | Responsabilidad |
|---------|----------------|
| `Program.cs` | Renderiza la pantalla de bienvenida, ejecuta el bucle del menú, enruta la entrada del usuario |
| `Task.cs` | Contiene `AddTask`, `UpdateTask`, `UpdateProgress`, `DeleteTask`, `ReadTasks` |
| `TextArt.cs` | Banners ASCII (`Welcome`, `Bye`) y helpers de color (`SuccessMsg`, `ErrorMsg`, `WarningMsg`, `QuestionMsg`) |

---

## ✅ Prerrequisitos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

| Herramienta | Versión Mínima | Descarga |
|-------------|---------------|---------|
| **Visual Studio** | 2022 (v17+) | [visualstudio.microsoft.com](https://visualstudio.microsoft.com/) |
| **.NET SDK** | 8.0 | [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0) |
| **Git** | Cualquiera | [git-scm.com](https://git-scm.com/) |

> Puedes verificar tu versión de .NET ejecutando `dotnet --version` en una terminal. Debe retornar `8.x.x`.

---

## ▶️ Cómo Ejecutar (Visual Studio)

### Paso 1 — Clonar el repositorio

```bash
git clone https://github.com/IgnacioRV23/Terminal-To-Do-List.git
cd Terminal-To-Do-List
```

### Paso 2 — Abrir la solución en Visual Studio

1. Abre **Visual Studio 2022**.
2. Haz clic en **"Abrir un proyecto o solución"** desde la pantalla de inicio.
3. Navega hasta la carpeta clonada y selecciona el archivo:
   ```
   Terminal - To Do List - CSHARP.sln
   ```
4. Visual Studio cargará la solución automáticamente.

### Paso 3 — Restaurar paquetes NuGet

Visual Studio generalmente restaura los paquetes al cargar. Si no:

- Ve a **Herramientas → Administrador de paquetes NuGet → Administrar paquetes NuGet para la solución**
- Haz clic en **"Restaurar"**, o haz clic derecho sobre el proyecto en el Explorador de soluciones y selecciona **"Restaurar paquetes NuGet"**

La única dependencia externa es:

```xml
<PackageReference Include="ConsoleTableExt" Version="3.3.0" />
```

### Paso 4 — Configurar el proyecto de inicio

En el **Explorador de soluciones**, haz clic derecho sobre `Terminal - To Do List - CSHARP` y selecciona **"Establecer como proyecto de inicio"**.

### Paso 5 — Ejecutar la aplicación

Presiona **`F5`** (con depuración) o **`Ctrl + F5`** (sin depuración) para iniciar la aplicación.

> 💡 **Consejo:** Usa `Ctrl + F5` para que la ventana de consola permanezca abierta al finalizar la ejecución.

Se abrirá una ventana de terminal mostrando el banner de bienvenida en ASCII art, seguido del menú principal.

### Alternativa — Ejecutar con la CLI de .NET

Si prefieres la línea de comandos:

```bash
dotnet restore
dotnet run --project "Terminal - To Do List - CSHARP.csproj"
```

---

## 🗂️ Referencia del Menú

Al iniciar la aplicación, verás el siguiente menú:

```
+------------------------+
|       Main Menu        |
|   Add Task      [A]    |
|   Update Task   [U]    |
|   Update Progress [P]  |
|   Delete Task   [D]    |
|   List Tasks    [R]    |
|   Close System  [X]    |
+------------------------+
```

Escribe la letra indicada entre corchetes y presiona `Enter` para ejecutar la acción correspondiente. La entrada es **insensible a mayúsculas** (`a` y `A` funcionan igual).

---

## 🧪 Casos de Uso y Ejemplos de Prueba

Los siguientes escenarios recorren todas las funcionalidades de la aplicación desde cero.

---

### ✅ Caso de Prueba 1 — Agregar una Tarea (presionar `A`)

**Secuencia de prompts:**

```
Task name:
> Comprar víveres

Task description:
> Leche, huevos, pan y café

Task priority
High [H]
Medium [M]
Low [L]
> L
```

**Salida esperada:**

```
Task created successfully.
```

Se agrega una nueva tarea a la lista en memoria con:
- ID generado (por ejemplo, `1010`)
- Prioridad: `Low`
- Progreso: `To do`
- Fecha de creación: marca de tiempo actual

---

### ✅ Caso de Prueba 2 — Agregar una Segunda Tarea (presionar `A`)

```
Task name:
> Corregir bug de login

Task description:
> Los usuarios no pueden iniciar sesión luego de restablecer la contraseña

Task priority
> H
```

**Salida esperada:**

```
Task created successfully.
```

Se agrega una segunda tarea con ID `1020`, Prioridad `High`, Progreso `To do`.

---

### ✅ Caso de Prueba 3 — Listar Todas las Tareas (presionar `R`)

**Salida esperada** (renderizada como tabla):

```
╔══════╦══════════════════════╦══════════════════════════════════════╦══════════╦══════════╦════════════════════╦══════════════╗
║  ID  ║ Name                 ║ Description                          ║ Priority ║ Progress ║ Created Date       ║ Updated Date ║
╠══════╬══════════════════════╬══════════════════════════════════════╬══════════╬══════════╬════════════════════╬══════════════╣
║ 1010 ║ Comprar víveres      ║ Leche, huevos, pan y café            ║ Low      ║ To do    ║ 04/21/2025 10:30AM ║              ║
║ 1020 ║ Corregir bug de login║ Usuarios no pueden iniciar sesión... ║ High     ║ To do    ║ 04/21/2025 10:31AM ║              ║
╚══════╩══════════════════════╩══════════════════════════════════════╩══════════╩══════════╩════════════════════╩══════════════╝
```

Presiona cualquier tecla para volver al menú.

---

### ✅ Caso de Prueba 4 — Actualizar Información de una Tarea (presionar `U`)

Primero verás la lista de tareas, luego:

```
Enter the ID of the task to be updated:
> 1020

Enter update task name:
> Corregir bug de autenticación

Enter update task description:
> Investigar expiración de token JWT

Enter update task priority
High [H]  /  Medium [M]  /  Low [L]
> M
```

**Salida esperada:**

```
Information updated successfully.
```

La tarea `1020` ahora tiene nombre, descripción y prioridad `Medium` actualizados, junto con una nueva marca de tiempo en `Updated Date`.

---

### ✅ Caso de Prueba 5 — Actualizar Progreso (presionar `P`)

```
Enter the ID of the task to be updated:
> 1010

Enter new progress task:
To do [T]
In Progress [P]
Done [D]
> P
```

**Salida esperada:**

```
Information updated successfully.
```

La tarea `1010` ahora muestra `In Progress` en la columna de progreso.

---

### ✅ Caso de Prueba 6 — Eliminar una Tarea (presionar `D`)

```
Enter the ID of the task to be deleted:
> 1010

Are you sure you want to delete task 1010?
Yes [Y]
No [N]
> Y
```

**Salida esperada:**

```
Information deleted successfully.
```

La tarea `1010` es eliminada permanentemente de la lista.

**Si elijes `N`:**

```
Information not deleted.
```

---

### ✅ Caso de Prueba 7 — Manejo de Errores

**Listar tareas cuando no existe ninguna:**

```
> R
Tasks not found. :(
```

**Ingresar un ID inexistente:**

```
Enter the ID of the task to be updated:
> 9999

Task ID 9999 not found. :(
```

**Ingresar una prioridad inválida repetidamente:**

```
Task priority
> Z        ← inválido, el bucle se repite
Task priority
> X        ← inválido, el bucle se repite
Task priority
> H        ← aceptado
```

---

### ✅ Caso de Prueba 8 — Cerrar la Aplicación (presionar `X`)

La aplicación muestra el banner de despedida en ASCII art y termina de forma limpia.

---

## 📦 Modelo de Datos de Tarea

Cada tarea se almacena como un `List<object>` con los siguientes campos en orden:

| Índice | Campo | Tipo | Ejemplo |
|--------|-------|------|---------|
| 0 | ID | `int` | `1010` |
| 1 | Nombre | `string` | `"Corregir bug de login"` |
| 2 | Descripción | `string` | `"Investigar expiración JWT"` |
| 3 | Prioridad | `string` | `"High"` / `"Medium"` / `"Low"` |
| 4 | Progreso | `string` | `"To do"` / `"In Progress"` / `"Done"` |
| 5 | Fecha de Creación | `string` | `"04/21/2025 10:30AM"` |
| 6 | Fecha de Actualización | `string` | `"04/21/2025 11:00AM"` o `""` |

> **Nota:** Todos los datos se almacenan **únicamente en memoria**. Las tareas se pierden al cerrar la aplicación. No hay base de datos ni persistencia en archivos.
