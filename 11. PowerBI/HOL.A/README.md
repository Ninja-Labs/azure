#Haciendo Inteligencia de Negocios en la Nube con Power BI
En este laboratorio usaremos Microsoft Power BI, para crear tableros de control en la nube, modelando las fuentes de datos, creando indicadores, para ponerlos en el servicio de Power BI.

##Paso 1 - Conectarse al almacén de datos
Para este ejercicio dispondremos de una BD en Azure con datos de prueba, esto con el fin de agilizar el ejercicio, una copia de esta base de datos podrá en contrarla en:
    * https://github.com/MicrosoftLearning/Analyzing-Visualizing-Data-PowerBI/blob/master/Lab1/PowerBI%20AccessDB.zip
    
```
Servidor: cloudcamp.databases.windows.net
Database: cloudcampbi
Usuario: db
Contraseña: "Se entragará de forma presencial"
```
La base de datos originalmente se encuentra diseñada en Microsoft Access, pero para facilidad de este cloud camp, la hemos convertido a SQL Azure, usando la herramienta SSMA (https://msdn.microsoft.com/en-us/library/hh313088(v=sql.110).aspx)

1. Descargue e instale el cliente de Power BI a su máquina.
    * https://powerbi.microsoft.com/es-es/desktop/
2. Descargue los elementos de datos complementarios para el laboratorio.
    * https://github.com/MicrosoftLearning/Analyzing-Visualizing-Data-PowerBI/raw/master/Lab1/CountryPopulationByYear.zip
    * https://github.com/MicrosoftLearning/Analyzing-Visualizing-Data-PowerBI/raw/master/Lab1/InternationalSales.zip

##Paso 2 - Iniciando con la importación de datos
1. Inicie un nuevo proyecto de Power BI.
2. Conectese con la información del punto 1 usando el boton Get_Data
    * esto puede hacerlo con el servidor de SQL Azure o a su BD de Microsoft Access.
3. Selecciones todas la tablas para consultadas, se recomienda usar Direct Query, de lo contrario el asistente importará los datos de la base de datos a la máquina local para analizarlos.
4. Edite el query antes de cargarlo.
    * Filtre las filas de bi_salesFact para que solo incluya los datos desde el 1 de Enero del 2000.
    * Filtre las filas de bi_date para que solo incluya los datos desde el 1 de Enero del 2000.
5. Renombre los querys de la siguiente forma:
```
bi_date: Date
bi_geo: Locations
bi_manufacturer: Manufacturers
bi_product: Products
bi_salesFact: Sales
``` 
6. Repita estos pasos pero cargando International Sales and Country Population By Year.

##Paso 3 - Creando Medidas en el almacén de datos.
1. Seleccione la tabla Sales
2. Haga click en el botón "New Measure"
    * Esto creará una nueva columna, ingrese en la barra de formulas : " TotalSales = SUM(Sales[Revenue]) ".
3. Repita la operación creando las siguientes medidas:
    * LY Sales = CALCULATE([Total Sales];SAMEPERIODLASTYEAR('Date'[Date]))
    * Sales Var = [Total Sales] - [LY Sales]
    * Sales Var % = DIVIDE([Sales Var];[LY Sales])
    * YTD Sales = TOTALYTD([Total Sales];'Date'[Date])
    * LY YTD Sales = CALCULATE([YTD Sales];SAMEPERIODLASTYEAR('Date'[Date]))
    * YTD Sales Var = [YTD Sales] - [LY YTD Sales]
    * YTD Sales Var % = DIVIDE([YTD Sales Var];[LY YTD Sales])
    * Total VanArsdel Sales = CALCULATE([Total Sales];Manufacturers[Manufacturer]="VanArsdel")
    * % Sales Market Share = IF([Total VanArsdel Sales]=0;0;DIVIDE([Total VanArsdel Sales];[Total Sales];0))

Las medidas YTD representan el un periodo de tiempo desde el comienzo del año actual hasta la fecha actual, estas medidas son especiales y nos permitirán comparar con las medidas LY que representan el ultimo año, con estas comparaciones podremos medir el crecimiento de los datos, que para este caso representan el crecimiento en ventas.

##Paso 4 - Visualizando Datos

1. Abra la vista de Reportes.
2. Arraste el campo "Total Sales" de la tabla Sales al el reporte para crear un gráfico.
3. Arraste los campos MonthName y Year de la tabla Date al gráfico anterior.
4. Modifique el gráfico para usar la visualización de Matríz (Matrix)
    * Establezca el Mes en las filas y el año en las columnas.

##Paso 5 - Gráficando Datos.

1. Cree una nueva página haciendo click en el icono "+" en la parte inferior.
2. Arrastre el campo "Total Sales" de la tabla de ventas para crear un gráfico.
3. Arraste los campos "Category" y "Segment" de la tabla de productos al gráfico.
4. Modifique el gráfico para usar la visualización "100% Stacked Bar Chart".
5. Verifique que el campo "Category" está ubicado en el Eje (Axis) y el campo "Segment" en la leyenda (Legend).
6. Personalice el formato de la visualización y seleccione "Data Labels", además ajuste la precisión a 0.
7. Repita estos mismos pasos pero esta vez use:
    * Total Sales - Tabla : Sales.
    * Manufactures - Tabla: Manufacturers.
    * Use el Treemap Visualization.
8. Arrastre el campo MonthName a la tabla para crear una visualización.
9. Modifique esta última para usar "Slicer visualization".
10. Repita los pasos 8 y 9 para el campo Year de la tabla Date.

##Paso 6 - Otras Visualizaciones.
1. Cree una nueva página haciendo click en el icono "+" en la parte inferior.
2. Cree una visualización arrastrando el control "waterfall Chart visualization".
3. Arrastre sobre dicha visualización los campos:
    * Sales Var - Tabla: Sales.
    * Year - Tabla: Date.