# GitHub Copilot Instructions for RimWorld Mod: Decorative Trees (Continued)

## Mod Overview and Purpose

The "Decorative Trees (Continued)" mod is an enhancement of the original mod created by Cattleyas, updated to ensure compatibility with the current version of RimWorld. The purpose of this mod is to introduce unique trees that can be used to improve colonists' environments and functionalities. This mod adds two unusual trees, the Silver tree and the Party tree, which require specific conditions to grow and offer distinctive benefits to your colony. 

## Key Features and Systems

- **Decorative Tree Pot**: This mod introduces a new plant pot containing alien soil, specifically designed for growing the unique Decorative Trees. It is specially engineered to prevent the trees from growing too large, making it possible to place them indoors.

- **Silver Tree**: A unique tree that enhances beauty and provides silver upon harvest. After harvesting, the tree recedes to a smaller size, allowing continual regrowth without the need to purchase new stalks.

- **Party Tree**: A visually appealing fir tree with the added functionality to be adorned for parties. Colonists can throw a party, provided there are no ill events occurring during the attempt.

- **Seamless Compatibility**: The mod is designed to work smoothly with other mods and has been validated with the Hardcore SK mod pack.

- **Optional Seed System**: While the mod supports seed-based planting, it remains optional and compatible with the SeedsPlease mod. 

## Coding Patterns and Conventions

- Utilize descriptive, clear class and method names for ease of maintenance and readability, such as `CompProperties_DecorativeTrees` and `JobDriver_GoToThrowParty`.

- Maintain consistent coding style in regards to indentation, spacing, and brace positioning that aligns with C# conventions.

- Utilize access modifiers appropriately to encapsulate class properties and methods, promoting secure and maintainable code.

## XML Integration

- Define plant and job properties using XML-based def files, allowing for easy configuration and tuning of mod content.

- Utilize distinct XML files for separate entities for modularization, such as `DecorativeTreeDefs.xml` for tree definitions and `JobDefs_PartyTree.xml` for job actions.

## Harmony Patching

- Utilize Harmony to patch the game's methods, ensuring that the mod’s functionality integrates seamlessly with the existing game mechanics. Given the potential for compatibility issues, Harmony's prefix, postfix, and transpile methods can be selectively applied to carefully target the necessary game code.

## Suggestions for Copilot

- **Predictive Suggestions**: Utilize Copilot for predictive code suggestions when writing new classes or methods, potentially reducing common errors and improving development efficiency.

- **XML Validation**: Leverage Copilot to ensure the XML files adhere to required schema standards.

- **Debugging Assistance**: While working on patches using Harmony, Copilot can suggest potentially useful debug statements to confirm that patches are applied correctly.

- **Code Commenting**: Use Copilot to generate informative summaries and comments for code sections, aiding in documentation and knowledge transfer.

- **Template Generation**: Request Copilot to create templates for new features or expansions in the mod, following established conventions within the project.

By following these instructions, developers working on the Decorative Trees (Continued) mod will be equipped to effectively enhance, maintain, and expand the mod's functionality.
