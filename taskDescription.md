# Task TODO Application (Full Stack Developer)

# Overview

Create REST API and JavaScript based UI for **Todo List Application**.

All endpoints should return valid JSON, headers and proper HTTP status codes.

## Frontend

The user interface should be JavaScript based preferably using **Vue 3** (with Options API and **optionally** the Composition API) ****and **Vite** build toolset.

Following features should be available:

- List of tasks
- Option to add a new task with title, description and initial state
- For each task there is a button to completely delete it with confirmation
- For each task there is a button to change task state - open, in progress, finished
- Optionally - for better state management use **Vuex**

<aside>
💡 For styling, if possible, use **SCSS**.

</aside>

### Data Storage

Use API as single source of truth, but if you want to - use `Local Storage` or `IndexedDB` to cache items for faster page loading when opened from scratch or any other use-case.

## Backend

Use latest .**NET 9/ASP.NET** and **C#** to create backend part of this application.

Please try to **minimize** any usage of external NuGets or libraries.

If possible:

- Use async where appropriate
- Make smart choices in terms of performance

### Data Storage

For data storage use:

- **SQLite** database, but do **NOT** use any ORM like Entity Framework, write SQL queries manually (Dapper is fine)
- **LiteDB** or **RavenDB** database for No-SQL type of storage

> If you want to, you may use full fledged database like PostgreSQL or MongoDB, but it is NOT a requirement, but if you will go this way - please wrap whole system to **Docker Compose** in order to provide “one click” start.
> 

*Are you interested in **which databases** we are using in Elixeum? **Checkout** this blog post [Mixing it up: Using several different databases for our platform - Elixeum Tech Blog](https://tech.elixeum.com/post/mixing-it-up-using-several-different-databases-for-our-platform.html)*

## Container

As a **bonus** point - wrap this service into **Docker** container, which means - create `Dockerfile` which builds this service and runs it properly with serving API and UI.

# **Implementation Details**

- IDs are stored as **UUIDv4** or UUIDv7/UUIDv8
- Endpoints returns valid **JSON** objects

## Structures

<aside>
💡 Following structures are suggestions, feel free to extend them by your ideas.

</aside>

### **Todo Item Structure**

```json
{
  "id": "bd3e82ce-6643-4851-8755-324c4da7c680",
	"title": "Example Todo Item",
	"state": "1",
	"content": "Long text content/description of this todo item"
}
```

Where `state` is:

- `1` open
- `2` in-progress
- `3` finished

### **Error Structure**

In case of any error - use unified error structure in response.

```json
{
	"isError": "true",
	"error": {
	   "code": "123456",
	   "message": "Something failed"
	}
}
```

### **Application Endpoints**

`GET /todo`

- Returns list of all items in list
- Filter the list based on query argument `?state=created|finished|all`, if no argument is specified, list all

`GET /todo/<id>`

- Returns single item based on ID

`POST /todo`

- Creates new todo item

`PUT /todo/<id>`

- Updates existing todo item, for example state change from created to finished

`DELETE /todo/<id>`

- Deletes todo based on ID