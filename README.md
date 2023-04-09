
# Prueba técnica UDD

Git repo para prueba técnica postulación desarrollador analista UDD.


## Authors

- [@GustavoBustamante](https://github.com/GustavoABustamante)


## API Reference

#### Get Persona por Id

```http
  GET /api/Persona/${personaId}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `personaId` | `int` | **Required**. Id es requerido para retornar un objeto Json que contiene la información de la persona. |

#### Add Persona

```http
  POST /api/Persona/
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `{nombre: string, fechaIngreso: Date}`      | `json` | **Required**. nombre y fecha son requeridos para el ingreso del registro de la persona. Se toma el valor de fechaIngreso y se evalua si corresponde a un feriado legal en Chile a través de la API del gobrierno. |

#### Delete Persona

```http
  DELETE /api/Persona/${personaId}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `personaId` | `int` | **Required**. Id es requerido para eliminar el registro de la persona. |



## Run Locally

Clone the project

```bash
  git clone https://github.com/GustavoABustamante/PRUEBA_TECNICA_UDD.git
```

Download the SQL Server 2022 database docker image

```bash
  docker pull mcr.microsoft.com/mssql/server:2022-latest
```

Download and install docker desktop

```bash
  https://hub.docker.com/
```

Go to the projects folder and run

```bash
  docker compose build
```
Or open the solution on Visual Studio

```bash
  Play docker compose
```
