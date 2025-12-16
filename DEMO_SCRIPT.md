# BookStore Custom Agents Demo Script

Bu demo script, GitHub Copilot Custom Agents ve Instructions özelliklerini BookStore projesi üzerinde göstermek için hazırlanmıştır.

## Demo Bilgileri

- **Süre**: 25 dakika
- **Hedef Kitle**: Geliştiriciler, teknik liderler
- **Konu**: Custom agents ile modüler, özelleştirilmiş kod geliştirme workflow'u
- **Teknolojiler**: .NET 10, xUnit, React 18, TypeScript, Tailwind CSS

## Prerequisites

Demo öncesi hazırlıklar:

### Gerekli Araçlar
```bash
# .NET SDK 10.0
dotnet --version

# Node.js 18+
node --version

# VS Code + GitHub Copilot Chat extension
code --version
```

### Proje Durumu
- ✅ BookStoreAPI: Basic CRUD endpoints mevcut
- ❌ Tests: Test projesi boş
- ❌ Frontend: UI projesi boş
- ✅ Instructions: Global ve agent-specific dosyalar hazır

### Workspace Dosyaları
```
book-store-demo/
├── .github/
│   ├── instructions/
│   │   └── copilot-instructions.md  # Global standards (HIGHEST PRIORITY)
│   └── agents/
│       ├── test.agent.md            # Test Agent definition
│       ├── backend.agent.md         # Backend Agent definition
│       └── frontend.agent.md        # Frontend Agent definition
├── designs/                         # Wireframes (kullanıcı ekleyecek)
├── BookStoreAPI/                    # Mevcut API
├── BookStoreAPI.Tests/              # Boş test projesi
└── BookStoreUI/                     # Boş UI projesi
```

---

## Act 1: Introduction (3 dakika)

### Proje Tanıtımı

**Senaryo Açıklaması**:
> "Bir müşterimiz temel bir kitap yönetim API'si geliştirmiş ama test, validasyon ve frontend kısmı eksik. Bu projeyi **3 özel agent** kullanarak tamamlayacağız."

**Mevcut Kodu Gösterme**:
1. VS Code'da `BookStoreAPI/Controllers/BooksController.cs` aç
2. CRUD endpoint'lerini göster (GetAll, GetById, Create, Update, Delete)
3. `BookStoreAPI/Models/Book.cs` aç - basit model (Id, Title, Author, Price, PublishedYear)
4. Sorunları vurgula:
   - ❌ Test yok
   - ❌ Validation yok
   - ❌ Database entegrasyonu yok (in-memory list)
   - ❌ Frontend yok

**Custom Agents Konsepti**:
> "Custom agents, belirli bir alanda uzmanlaşmış AI asistanlarıdır. Her agent:
> - Kendi instruction dosyasına sahip
> - Belirli standartlara uyar
> - Kendi alanında deep expertise sunar"

**Instructions Hierarchy**:
```
.github/instructions/copilot-instructions.md  ← HIGHEST PRIORITY: Global rules (proje-wide)
         ↓ (agent-specific extensions)
.github/agents/test.agent.md                  ← Test-specific guidelines
.github/agents/backend.agent.md               ← Backend-specific guidelines
.github/agents/frontend.agent.md              ← Frontend-specific guidelines
```

> "⚠️ **ÖNEMLİ**: Conflict durumunda **global copilot-instructions.md dosyası her zaman önceliklidir**. Agent-specific dosyalar sadece ek context ve uzmanlaşmış best practice'ler sağlar, asla global standartları override etmez. İsimlendirme kuralları, kod stili, mimari kararlar gibi şirket standartları copilot-instructions.md dosyasında tanımlanmalıdır."

---

## Act 2: Agent Introduction (2 dakika)

### Agent Tanıtımları

#### 1. Test Agent 🎯
**Sorumluluklar**:
- xUnit test yazma
- AAA pattern enforcement
- FluentAssertions kullanımı
- %80+ code coverage hedefi

**Kişilik**: Friendly, encouraging ("Testleri tamamladım! %87 coverage'a ulaştık 🎯")

**Dosya**: `.github/agents/test.agent.md` göster

---

#### 2. Backend Agent 🚀
**Sorumluluklar**:
- API endpoint geliştirme
- Entity Framework Core entegrasyonu
- Service layer pattern
- FluentValidation

**Kişilik**: Professional, proactive ("Service layer ekledim! Business logic artık ayrı 🚀")

**Dosya**: `.github/agents/backend.agent.md` göster

---

#### 3. Frontend Agent 🎨
**Sorumluluklar**:
- React + TypeScript component'leri
- API entegrasyonu
- Tailwind CSS styling
- Görsel referans (wireframe) kabul etme

**Kişilik**: Creative, user-focused ("Component'leri hazırladım! Responsive design de tamam 🎨")

**Dosya**: `.github/agents/frontend.agent.md` göster

**⚠️ ÖNEMLİ NOT**: Her üç agent de `.github/instructions/copilot-instructions.md` dosyasındaki global standartlara uymak zorundadır. İsimlendirme kuralları, kod formatı gibi şirket standartları agent'lar tarafından değil, copilot-instructions dosyası tarafından belirlenir.

---

## Act 3: Interactive Demo (18 dakika)

### Step 1: Test Agent - Controller Testleri (1.5 dk)

**Amaç**: BooksController için kapsamlı unit testler

**Copilot Chat'i Aç** → Test Agent'ı seç

**Prompt**:
```
@test-agent BooksController'daki GetAllBooks ve GetBookById metodları için kapsamlı unit testler yaz.
AAA pattern kullan ve happy path + edge case senaryolarını kapsasın.
```

**Beklenen Çıktı**:
- `BookStoreAPI.Tests/Controllers/BooksControllerTests.cs` oluşturulur
- Test methods:
  - `BooksControllerTests_GetAllBooks_WhenCalled_ReturnsOkWithAllBooks()`
  - `BooksControllerTests_GetBookById_WhenBookExists_ReturnsOkWithBook()`
  - `BooksControllerTests_GetBookById_WhenIdNotFound_ReturnsNotFoundResult()`
- FluentAssertions kullanılır
- Turkish XML comments

**Verification**:
```bash
cd BookStoreAPI.Tests
dotnet test --collect:"XPlat Code Coverage"
```

---

### Step 2: Test Agent - Edge Case Testleri (1.5 dk)

**Amaç**: CreateBook için validation ve error testleri

**Prompt**:
```
@test-agent CreateBook metodu için şu senaryoları test et:
1. Valid book ile başarılı creation
2. Null book ile ArgumentNullException
3. Duplicate ID durumu
```

**Beklenen Çıktı**:
- 3 yeni test metodu eklenir
- Exception handling testleri
- Theory attribute ile parametreli testler

**Verification**:
```bash
dotnet test --logger "console;verbosity=detailed"
```

---

### Step 3: Coverage Report (1 dk)

**Amaç**: Test coverage metriklerini göster

**Terminal**:
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./TestResults/
```

**Beklenen**:
- Coverage %80+
- BooksController tüm metodları covered

**Ekran Gösterimi**: Coverage raporunu aç ve vurgula

---

### Step 4: Backend Agent - Model Genişletme (2 dk)

**Amaç**: Book modeline ISBN ve CategoryId ekle, validation kur

**Copilot Chat** → Backend Agent'ı seç

**Prompt**:
```
@backend Book modeline şu property'leri ekle:
- ISBN: string (13 karakter, opsiyonel)
- CategoryId: int (nullable)

FluentValidation ile validation kuralları da ekle.
```

**Beklenen Çıktı**:
- `BookStoreAPI/Models/Book.cs` güncellenir:
  ```csharp
  public string? ISBN { get; set; }
  public int? CategoryId { get; set; }
  ```
- `BookStoreAPI/Validators/BookValidator.cs` oluşturulur:
  ```csharp
  RuleFor(x => x.ISBN)
      .Length(13).WithMessage("ISBN 13 karakter olmalıdır")
      .When(x => !string.IsNullOrEmpty(x.ISBN));
  ```

**Verification**: Swagger'ı aç, model şemasını göster

---

### Step 5: Backend Agent - Search Endpoint (2 dk)

**Amaç**: Kitaplarda arama endpoint'i ekle

**Prompt**:
```
@backend Kitaplar için arama endpoint'i ekle:
GET /api/books/search?query={term}

Title ve author alanlarında case-insensitive arama yapsın.
Service layer pattern kullan.
```

**Beklenen Çıktı**:
- `BookStoreAPI/Services/IBookService.cs` ve `BookService.cs` oluşturulur
- `BooksController.cs` güncellenir:
  ```csharp
  [HttpGet("search")]
  public async Task<ActionResult<IEnumerable<Book>>> SearchBooks([FromQuery] string query)
  ```
- Service'te LINQ query:
  ```csharp
  return await _context.Books
      .Where(b => b.Title.ToLower().Contains(query.ToLower()) || 
                  b.Author.ToLower().Contains(query.ToLower()))
      .ToListAsync();
  ```

**Verification**:
```bash
# Terminal'de test
curl "http://localhost:5134/api/books/search?query=orwell"
```

---

### Step 6: Test Agent - Search Endpoint Testleri (1.5 dk)

**Amaç**: Yeni search endpoint için testler

**Prompt**:
```
@test-agent Yeni eklenen search endpoint'i için testler yaz:
- Boş query ile tüm kitapları dönmeli
- Geçerli query ile eşleşen kitapları bulmalı
- Hiç eşleşme olmayan query ile boş liste dönmeli
```

**Not**: Manuel context sağlama - agent başka agent'ın çıktısını bilmiyor

**Beklenen Çıktı**:
- `SearchBooks_*` test metodları eklenir
- Theory attribute ile farklı query'ler test edilir

**Verification**:
```bash
dotnet test --filter SearchBooks
```

---

### Step 7: Frontend Agent - BookList Component (2 dk)

**Amaç**: Wireframe'den BookList component'i oluştur

**Hazırlık**: 
- `designs/book-list-wireframe.png` dosyasını kullanıcının önceden ekle(miş) olduğunu varsay
- Veya clipboard'a wireframe kopyala

**Copilot Chat** → Frontend Agent'ı seç

**Prompt (Görsel ile)**:
```
@frontend designs/book-list-wireframe.png dosyasındaki tasarıma göre BookList component'ini oluştur.

Gereksinimler:
- Grid layout: 3 column (desktop), 2 (tablet), 1 (mobile)
- Her kitap için card component
- API'den veri çeksin (bookService)
- Loading ve error state'leri
```

**Alternatif Prompt (Görsel olmadan)**:
```
@frontend BookList component'i oluştur:
- API'den kitapları çek
- Grid layout (responsive)
- Her kitap için: başlık, yazar, fiyat, cover placeholder
- Loading spinner ve error handling
```

**Beklenen Çıktı**:
- `BookStoreUI/src/components/books/BookList.tsx`
- `BookStoreUI/src/components/books/BookCard.tsx`
- `BookStoreUI/src/services/api/bookService.ts`
- `BookStoreUI/src/services/api/apiClient.ts`
- `BookStoreUI/src/types/Book.ts`

**Verification**:
```bash
cd BookStoreUI
npm install
npm run dev
```

Browser: http://localhost:3000

---

### Step 8: Frontend Agent - Search UI (2 dk)

**Amaç**: Arama fonksiyonu ekle

**Prompt**:
```
@frontend BookList component'ine arama özelliği ekle:
- Input field + search button
- Boş iken tüm kitaplar, yazarken filtreleme
- Debounce ile API call (500ms)
```

**Beklenen Çıktı**:
- `BookList.tsx` güncellenir
- Search input + button eklenir
- `bookService.searchBooks(query)` API call
- useState ile search state yönetimi

**Verification**: Browser'da arama kutusunu test et

---

### Step 9: Frontend Agent - BookForm Modal (2 dk)

**Amaç**: Yeni kitap ekleme formu

**Prompt**:
```
@frontend Yeni kitap eklemek için BookForm component'i oluştur:
- Modal içinde gösterilsin
- React Hook Form kullan
- Alanlar: title, author, price, publishedYear, ISBN
- Turkish validation mesajları
- Başarılı kayıtta modal kapansın ve liste yenilensin
```

**Beklenen Çıktı**:
- `BookStoreUI/src/components/books/BookForm.tsx`
- `BookStoreUI/src/components/common/Modal.tsx`
- React Hook Form entegrasyonu
- Turkish error messages: "Kitap başlığı gereklidir"

**Verification**: UI'da "Yeni Kitap Ekle" butonuna tıkla, form aç, validation test et

---

### Step 10: End-to-End Test (1 dk)

**Amaç**: Tüm sistemi test et

**Adımlar**:
1. Backend'i çalıştır: `dotnet run --project BookStoreAPI`
2. Frontend'i çalıştır: `npm run dev --prefix BookStoreUI`
3. Browser'da:
   - Kitap listesini görüntüle
   - Arama yap
   - Yeni kitap ekle
   - Detayları görüntüle

**Demo Flow**:
```
1. Liste yükleniyor → 3 kitap görünüyor
2. Search: "orwell" → 1984 bulunuyor
3. "Yeni Kitap Ekle" → Form aç
4. Doldur ve kaydet → Liste güncelleniyor ✓
```

---

## Act 4: Advanced Demo (2 dakika)

### Conflict Example: Agent Priority

**Senaryo**: Agent-specific instruction global'i override ediyor

**Prompt**:
```
@backend Search endpoint'i için pagination ekle ama repository pattern kullanma, direkt EF Core context kullan.
```

**Backend Agent Response**:
```
"Agent-specific instruction'a göre service layer pattern kullanıyorum ⚡
Repository pattern yerine service layer tercih ediliyor (agents/backend-agent.md kuralı).
Service layer hem daha temiz hem de test edilebilir bir çözüm.

BookService.SearchBooksPaginatedAsync() metodunu ekliyorum..."
```

**Açıklama**: Global instruction'da "repository pattern kullan" yazsa bile, agent kendi instruction'ını önceliklendiriyor.

---

### Error Recovery Example: Fallback Strategy

**Senaryo**: Frontend Agent'a eksik API URL ver

**Prompt**:
```
@frontend API'ye bağlan ve kitapları getir.
```

**Frontend Agent Response** (API URL yok):
```
"Backend'e bağlanırken hata aldık 🔌
.env dosyasında VITE_API_URL tanımlı değil gibi görünüyor.

Şu dosyayı oluşturmalısın:
.env
---
VITE_API_URL=http://localhost:5134/api

Oluşturduktan sonra `npm run dev` ile restart et. Yardım edelim mi?"
```

**Açıklama**: Agent eksik config'i tespit edip fallback strategy ile yardımcı oluyor.

---

## Act 5: Closing (2 dakika)

### Git Commit

**Terminal**:
```bash
git status
git add .
git commit -m "feat: Complete BookStore with custom agents

- Test Agent: Comprehensive unit tests with %87 coverage
  * BooksController tests with AAA pattern
  * Edge case and exception handling
  * FluentAssertions integration

- Backend Agent: Enhanced API features
  * Service layer pattern implementation
  * Search endpoint with filtering
  * FluentValidation for Book model
  * ISBN and CategoryId properties

- Frontend Agent: React UI implementation
  * BookList with responsive grid
  * Search functionality with debounce
  * BookForm with React Hook Form
  * Tailwind CSS styling
  * API service layer integration

Demo completed with 3 specialized custom agents."
```

---

### Demo Özeti

**Custom Agents Faydaları**:
✅ **Specialization**: Her agent kendi alanında expert  
✅ **Consistency**: Instructions ile kod standartları garanti  
✅ **Efficiency**: Agent switching ile hızlı context değişimi  
✅ **Maintainability**: Modüler yapı, kolay güncelleme  
✅ **Flexibility**: Agent-specific rules ile customize edilebilir  

**Instructions Hierarchy Değeri**:
- Global rules proje-wide tutarlılık sağlar
- Agent-specific rules flexibility sağlar
- Conflict resolution açık ve öngörülebilir

**Proje Sonucu**:
- ✅ %87 test coverage
- ✅ Clean architecture (service layer, validation)
- ✅ Modern UI (React 18 + TypeScript + Tailwind)
- ✅ Search, pagination, form validation
- ✅ Error handling ve responsive design

---

### Q&A Topics

Olası sorular:

**Q: Custom agent'ları nasıl oluştururum?**  
A: `agents/` klasöründe markdown dosyaları oluştur, rol ve standartları tanımla. VS Code Copilot Chat'te agent seçimi yaparsın.

**Q: Agent'lar birbirini görebilir mi?**  
A: Hayır, her agent independent. Kullanıcı manuel prompt ile context sağlamalı (örn: "yeni eklenen search endpoint'i için test yaz")

**Q: Global instructions her zaman geçerli mi?**  
A: Hayır, agent-specific instruction conflict durumunda önceliklidir.

**Q: Görsel referans nasıl verilir?**  
A: Clipboard'dan paste veya workspace'e kaydedip path ver (`designs/wireframe.png`)

**Q: Coverage threshold nasıl enforce edilir?**  
A: `coverlet.runsettings` veya CI/CD pipeline'da threshold tanımla. Demo'da gösterildi.

**Q: Agent personality özelleştirilebilir mi?**  
A: Evet, markdown dosyasında "Response Style" bölümünde ton ve dil tanımla.

**Q: Multi-agent workflow mümkün mü?**  
A: Hayır, şu anda manuel agent switching gerekli. Her adımda kullanıcı hangi agent'ı kullanacağını seçer.

---

## Demo Checklist

### Öncesi
- [ ] .NET 10 SDK yüklü
- [ ] Node.js 18+ yüklü
- [ ] VS Code + Copilot Chat extension aktif
- [ ] Proje clone edilmiş ve dependencies restore edilmiş
- [ ] `designs/` klasörüne wireframe eklenmiş
- [ ] Instructions dosyaları okunmuş

### Demo Sırasında
- [ ] Act 1: Proje tanıtımı ve konsept açıklaması
- [ ] Act 2: 3 agent tanıtımı (test, backend, frontend)
- [ ] Act 3: 10 adımlı interaktif senaryo
- [ ] Act 4: Conflict ve error recovery örnekleri
- [ ] Act 5: Git commit ve özet

### Sonrası
- [ ] Q&A session
- [ ] Feedback toplama
- [ ] Katılımcılara demo materials paylaşımı

---

## Ekstra Notlar

### Timing Adjustments
- 25 dakika standart demo
- Q&A için +10 dakika ayır
- Hızlı demo: Act 3'te 5-6 adım yap (15 dk total)
- Detaylı demo: Act 3'te tüm 10 adımı göster + Act 4 ekstra senaryo (30 dk)

### Backup Plan
Eğer canlı demo'da sorun çıkarsa:
- Pre-recorded video snippets hazırla
- Her adım için "before/after" screenshots al
- Git branch'leri kullan: `demo-step-1`, `demo-step-2` vs.

### Audience Customization
- **Technical Leads**: Act 4'e ağırlık ver (architecture decisions)
- **Developers**: Act 3'e ağırlık ver (hands-on coding)
- **Managers**: Act 1 ve Act 5'e ağırlık ver (benefits, ROI)

---

## Demo Başarı Kriterleri

✅ Katılımcılar custom agents konseptini anladı  
✅ Instructions hierarchy net bir şekilde gösterildi  
✅ Her 3 agent farklı personality ile çalıştı  
✅ End-to-end çalışan bir uygulama ortaya çıktı  
✅ Conflict resolution ve error recovery örnekleri verildi  
✅ Q&A'de sorular cevaplanabildi  

**Demo tamamlandı! 🎉**
