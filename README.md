i18n-extension
===========

## Step 1

Create your resource files (.resx) as usual.

## Step 2

Tell us which resource files you want to use.

    I18nConfig.SetResources(
        typeof(MyResources), 
        typeof(OthersResources), 
    );

## Step 3

Call extension method `.i18n()` on your strings or enum. The content will be translated according to the resource files. See tests for examples on usage and strategy for failed lookups.

    "Click here".i18n();
    Gender.Male.i18n();
    "FIRST_NAME".i18n();

## NuGet

This is not a NuGet package, you will need to download and compile or copy the classes from this project to yours.
