# WebTemplate

Pour initialiser le template, il est nécessaire dans un premier temps d'exporter les projets un a un
depuis: Projet => Exporter le modèle

![image](https://user-images.githubusercontent.com/6765644/194651110-877c6528-637e-4d70-94f6-263937b8ade3.png)

L'assistant d'exportation de modèle s'ouvre

![image](https://user-images.githubusercontent.com/6765644/194651405-6a5c9142-c183-491b-a1bc-b0fbcfbdc493.png)

Pour chaque projet, l'exportation doit être fait.

Une fois ceci fait, rendez vous dans le dossier **C:\Users\\{username}\Documents\Visual Studio 2022\My Exported Templates**

# Vstemplate

A l'aide d'un éditeur de texte, un fichier .vstemplate doit être créé.
Exemple: *WebTemplate.vstemplate*

```xml
<VSTemplate xmlns="http://schemas.microsoft.com/developer/vstemplate/2005" Version="3.0.0" Type="ProjectGroup">
	<TemplateData>
		<Name>Net6 Web Template</Name>
		<Description>Project template Architecture Hexagonal.</Description>
		<ProjectType>CSharp</ProjectType>
		<LanguageTag>C#</LanguageTag>
		<PlatformTag>Windows</PlatformTag>
		<ProjectTypeTag>Web</ProjectTypeTag>
			<CreateNewFolder>true</CreateNewFolder>
			<LocationField>Enabled</LocationField>
		</TemplateData>
	<TemplateContent>
		<ProjectCollection>
			<ProjectTemplateLink ProjectName="$safeprojectname$.Api" CopyParameters="true">WebTemplate.API\MyTemplate.vstemplate</ProjectTemplateLink>
			<ProjectTemplateLink ProjectName="$safeprojectname$.Domain" CopyParameters="true">WebTemplate.Domain\MyTemplate.vstemplate</ProjectTemplateLink>
			<ProjectTemplateLink ProjectName="$safeprojectname$.Infrastructure"     CopyParameters="true">WebTemplate.Infrastructure\MyTemplate.vstemplate</ProjectTemplateLink>
			<ProjectTemplateLink ProjectName="$safeprojectname$.Application" CopyParameters="true">WebTemplate.Application\MyTemplate.vstemplate</ProjectTemplateLink>
		</ProjectCollection>			
	</TemplateContent>
</VSTemplate>
```

**$safeprojectname$** remplace le nom du projet. (Voir https://learn.microsoft.com/uk-ua/visualstudio/extensibility/visual-studio-template-schema-reference?view=vs-2022)

Ensuite, chaque projet doivent être extraits afin de modifier le fichier template inclus dans chaqu'un d'entre eux.
Si besoin, ajouter des références de projets ou des fichiers supplémentaires à ajouter a la création du nouveau projet.

Si ce n'est pas encore fait, pensez à modifier les projets csproj pour remplacer le nom du projet de référence par safeprojectname.

Enfin, dans chaque projet, remplacer les using et autre namespace par le paramètre necessaire.
https://learn.microsoft.com/fr-fr/visualstudio/ide/template-parameters?view=vs-2022

# Dossier template format zip

Un template sous format Zip est disponible afin d'utiliser le projet comme template.
Vous devez le copier dans votre dossier Template.
Par défaut celui ci ce trouce dans : C:\Users\User\Documents\Visual Studio 2022\Templates\ProjectTemplates\C#
