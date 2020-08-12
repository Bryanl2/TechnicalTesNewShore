Tema que no manejo:
Pruebas Unitarias y/o Integración ----> traté de elaborarlas pero no lograba hacerlo de forma correcta, es un tema en el cuál me pondré al día en c# ya que soy consciente de su gran relevancia

Información Básica del proyecto:

	-Elabore la solución del problema planteado, creé y consumi un api REST por medio de Postman y de un MVC de la solución además de hacer un CRUD.
	-La solución la planteé en n-capas pensando en una aplicación escalable.
	-Dejé funcionales, aunque no consumí, apis asmx y wcf para mostrar la potencialidad escalable del proyecto.
	-La conexión a la base de datos lo hice por medio de una biblioteca de clases, para que funcionara en la solución agregue las dependecias necesarias a los demás proyectos (por medio de referencias y por NuGet)
	-Para consumir la api REST en el MVC hice que tuviese que comunicarse con la api, impidiendole una comunicación directa con la información (se recomienda por seguridad de información).
	-Para conectar la api REST con el MVC lo hice por medio de una biblioteca de clases.

Partes de la solución:

	-El problema principal de subir y leer los ficheros , además de forma uno nuevo descagable con la lista de los posibles clientes existentes o no está en:
	"TechnicalTestNewShore.Archives"

	-La conexión con la base de datos creada en sql server la cuál sostuvo toda la solución está en (biblioteca de clases):
	"TechnicalTestNewShore.WebServices.Data"

	-El desarrollo de la api REST junto a toda su lógica para el Get,Post,Put,Delete está en:
	"TechnicalTestNewShore.WebServices.WebApiRest"

	-El MVC junto con el CRUD desarrollado para consumir la api REST está en (también la consumí por Postman):
	"TechnicalTestNewShore.WebService.WebClient"

	-El modelo para representar la base de datos y comunicar la api REST con el MVC está en (biblioteca de clases):
	"TechnicalTestNewShore.WebServices.DomainOne"

	-Api ASMX (se dejó completamente funcional, pero sólo con el Get y no se consumió. Se hizo para mostrar lo escalable de la solución):
	"TechnicalTestNewShore.WebServices.ServiceASMX"

Anexo un vídeo mostrando como la solución web funciona correctamente con todo lo mencionado anteriormente.

Gracias.

	-Api WCF (se dejó completamente funcional, pero sólo con el Get y no se consumió. Se hizo para mostrar lo escalable de la solución):
	"TechnicalTestNewShore.WebServices.WCF"

