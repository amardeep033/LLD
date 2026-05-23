# Composite Pattern Interview Q&A (One-Liners)

## 1. What is Composite Pattern?

Lets you treat a single object and a group of objects through the same interface.

---

## 2. What are the three roles?

Component (interface), Leaf (no children), Composite (holds children).

---

## 3. What is the Component?

The shared interface both Leaf and Composite implement — the only type client code references.

---

## 4. What is the Leaf?

An end node with no children — it just executes the operation directly.

---

## 5. What is the Composite?

A node that holds a `List<IComponent>` and delegates every operation to its children.

---

## 6. What type does the Composite's children list hold?

The Component interface — so it can contain Leaves AND other Composites uniformly.

---

## 7. Why `List<IFileSystemItem>` and not `List<File>`?

`List<File>` can never hold a `Folder` — `List<IFileSystemItem>` holds both.

---

## 8. Why can't `BadFolder` contain another `BadFolder`?

Because its list is typed `List<BadFile>` — the type system physically prevents nesting.

---

## 9. What does the client code look like after Composite?

One `Add()` call for any item, one loop in `Show()` — no type checks anywhere.

---

## 10. What does the client code look like before Composite?

`AddFile()` for files, separate loop for folders, no shared method possible.

---

## 11. What design principle does Composite enforce?

Open/Closed — add a new item type (Symlink) by creating a class, not editing existing code.

---

## 12. What principle does `BadFolder` violate?

Open/Closed — adding `Symlink` means adding `AddSymlink()` and another loop in `Show()`.

---

## 13. How does recursion work in Composite?

`Folder.Show()` calls `item.Show()` on each child — if child is a Folder, it recurses automatically.

---

## 14. Who drives the recursion — the client or the composite?

The Composite — the client just calls `root.Show()` once.

---

## 15. Can a Composite be a child of another Composite?

Yes — a `Folder` inside a `Folder` is exactly this. That's what makes trees possible.

---

## 16. Can a Leaf have `Add()` / `Remove()`?

Technically yes (transparency approach), but it must throw `NotSupportedException` — files don't have children.

---

## 17. Transparency vs Safety — what's the difference?

Transparency: `Add/Remove` on the interface — simpler client, Leaf must throw. Safety: `Add/Remove` only on Composite — cleaner, but client must downcast.

---

## 18. What is the biggest sign you need Composite?

You write `if (x is File) ... else if (x is Folder) ...` — that if/else is the smell.

---

## 19. Difference between Composite and Decorator?

Composite is one-to-many (tree). Decorator is one-to-one (wrapping to add behavior).

---

## 20. Difference between Composite and Iterator?

Composite defines the tree structure. Iterator traverses it. They are often combined.

---

## 21. Real-world examples of Composite?

File system, HTML DOM, UI component trees, org charts, menu systems, expression trees.

---

## 22. Is `Show()` in `Folder` calling itself?

No — it calls `item.Show()` where `item` is `IFileSystemItem`. If `item` is a `Folder`, that `Folder`'s `Show()` runs — that's polymorphism, not direct recursion.

---

## 23. What breaks if you remove the interface?

No shared type — you cannot store File and Folder in one list or pass either to the same method.

---

## 24. Why is the bad output correct but the design still wrong?

The flat case works. The problem appears only when you try to nest — the type system blocks it.

---

## 25. Interview summary line?

Composite lets you compose objects into tree structures and treat individual objects and compositions uniformly.

---

Pattern roles      Class in example       Behaviour
Component          IFileSystemItem        shared interface — Leaf and Composite both implement it
Leaf               File                   executes Show() directly, no children
Composite          Folder                 delegates Show() to List<IFileSystemItem> recursively

---

Before composite                          After composite
List<BadFile> files                       List<IFileSystemItem> items
AddFile(BadFile file)                     Add(IFileSystemItem item)
two loops in Show()                       one loop in Show()
no nesting possible                       unlimited nesting
no shared type                            IFileSystemItem is the shared type
if/else in client                         polymorphism in Show()