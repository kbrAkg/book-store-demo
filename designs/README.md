# Designs Folder

This folder contains wireframe and mockup files for frontend development.

## Usage

When providing design reference to Frontend Agent, you can use files from this folder:

### Method 1: Workspace Path
```
@frontend Create BookList component according to designs/book-list-wireframe.png
```

### Method 2: Clipboard (Direct Paste)
You can copy the wireframe and paste it directly into Copilot Chat.

## Recommended File Structure

```
designs/
├── book-list-wireframe.png          # Main list page design
├── book-detail-wireframe.png        # Detail page design
├── book-form-wireframe.png          # Add/edit form design
├── search-ui-mockup.png             # Search UI mockup
└── mobile-responsive-design.png     # Mobile view
```

## Tips for Design Files

1. **Format**: Prefer PNG or JPG
2. **Resolution**: Minimum 1200px width
3. **File Name**: Be descriptive (e.g., `book-list-wireframe.png`)
4. **Content**: Layout, spacing, component hierarchy should be clear

## Example Wireframe for Demo

For demo purposes, you can draw a simple wireframe or prepare a design with these features:

### BookList Wireframe Features
- **Header**: Logo + title + search bar
- **Grid Layout**: 3 columns (desktop), 2 (tablet), 1 (mobile)
- **Book Card**: 
  - Cover placeholder (150x200px)
  - Title (bold, 18px)
  - Author (14px, gray)
  - Price (16px, blue, bold)
  - "Detaylar" button
- **Footer**: Copyright info

### Color Palette (Suggestion)
- Primary: #3B82F6 (Blue)
- Secondary: #6B7280 (Gray)
- Accent: #10B981 (Green)
- Background: #F9FAFB
- Text: #111827

## Frontend Agent Visual Analysis

Frontend Agent extracts this information from wireframe:

1. **Layout Structure**: Grid, flex, positioning
2. **Color Palette**: Primary, secondary, accent colors
3. **Typography**: Font sizes, weights, families
4. **Spacing**: Padding, margins, gaps
5. **Components**: Header, sidebar, cards, buttons, forms
6. **Responsive Breakpoints**: Mobile, tablet, desktop

## Example Usage Scenario

```
User: "Create BookList component according to designs/book-list-wireframe.png"

Frontend Agent:
"Analyzed the wireframe! 🎨
I see these elements in the design:
- Header: Logo (left) + 'Kitap Mağazası' title + search box (right)
- Grid: 3 columns desktop, responsive
- Card: Cover image placeholder, title, author, price, button
- Color scheme: Blue (#3B82F6) primary, gray backgrounds
- Spacing: 16px gap between cards, 24px padding

Creating components:
- BookList.tsx (main container)
- BookCard.tsx (card component)
- Header.tsx (header component)
- API service integration for data fetching

Applying responsive design with Tailwind CSS..."
```

## Notes

- ⚠️ This folder is initially empty. Add wireframe files here before demo.
- 💡 Designs exported from Figma, Sketch, Adobe XD can be used.
- 🎨 Even simple hand-drawn wireframes can be analyzed by Frontend Agent.
- 📱 For responsive design, you can show mobile and desktop versions separately.
