
# GolnoorUtility.ApiResponses

پکیج `GolnoorUtility.ApiResponses` مجموعه‌ای از کلاس‌ها و نوع‌های داده است که به منظور مدیریت پاسخ‌های API طراحی شده‌اند. این پکیج شامل انواع مختلفی از کدهای پاسخ، ساختارهای داده برای بازگشت نتایج و دسته‌بندی اطلاعات می‌باشد.

## محتوا

- [کلاس‌ها و توابع](#کلاس‌ها-و-توابع)
  - [ResponseCodes](#responsecodes)
  - [ApiResult<T>](#apiresultt)
  - [ApiResult](#apiresult)
  - [GroupingData<K, V>](#groupingdatak-v)
- [نحوه استفاده](#نحوه-استفاده)

---

## کلاس‌ها و توابع

### 1. `ResponseCodes`

این `enum` شامل کدهای مختلف پاسخ API است که می‌تواند برای شناسایی وضعیت پاسخ استفاده شود. این کدها به طور معمول برای تعیین وضعیت‌های مختلف از جمله موفقیت، خطاها و سایر وضعیت‌ها در API به کار می‌روند.

#### مقادیر `ResponseCodes`:

- **`succeed (200)`**: پاسخ موفق.
- **`DownloadLink (220)`**: درخواست موفق با لینک دانلود.
- **`DataAndDownloadLink (230)`**: درخواست موفق با داده‌ها و لینک دانلود.
- **`Unauthorized (401)`**: درخواست بدون مجوز.
- **`Forbidden (403)`**: دسترسی ممنوع.
- **`InputError (510)`**: خطای ورودی.
- **`DBError (560)`**: خطای پایگاه داده.
- **`HasChild (561)`**: داده دارای فرزند است.
- **`HasRelation (562)`**: داده دارای رابطه است.
- **`DuplicateData (563)`**: داده‌های تکراری.
- **`NotFoundData (564)`**: داده یافت نشد.
- **`SMSError (580)`**: خطا در ارسال پیامک.
- **`Error (500)`**: خطای داخلی سرور.
- **`ContentError (520)`**: خطا در محتوا.
- **`ErrorInFile (530)`**: خطا در فایل.
- **`LoopData (565)`**: داده در حال تکرار است.
- **`LicenceError (570)`**: خطا در مجوز.
- **`FileISDeActive (580)`**: فایل غیرفعال است.
- **`FileIsArchive (585)`**: فایل آرشیو شده است.
- **`WeightIsNullOrZero (623)`**: وزن صفر یا تهی است.
- **`CodeInTheInvoice (624)`**: کد در فاکتور موجود است.
- **`CodeInTheInquiry (625)`**: کد در استعلام موجود است.

### 2. `ApiResult<T>`

کلاس `ApiResult<T>` یک کلاس عمومی است که برای بازگشت نتایج API به همراه داده‌ها استفاده می‌شود. این کلاس از کلاس `ApiResult` ارث‌بری می‌کند و به آن نوع داده‌ای اضافه می‌کند که در پاسخ شامل می‌شود.

#### ویژگی‌ها:

- **`Data (T)`**: داده‌ای که در پاسخ باز می‌گردد (این ویژگی عمومی است و نوع آن به نوع مشخص شده به صورت پارامتر ژنریک `T` بستگی دارد).

#### مثال استفاده:

```csharp
return new ApiResult<string>
{
    IsSuccess = true,
    Message = "عملیات با موفقیت انجام شد.",
    ResponseCode = (int)ResponseCodes.succeed,
    Data = "داده‌های مورد نظر"
};
```
# GolnoorUtility.ApiResponses

پکیج `GolnoorUtility.ApiResponses` شامل کلاس‌ها و ساختارهایی است که برای مدیریت پاسخ‌های API و اطلاعات داینامیک استفاده می‌شوند. این پکیج به شما این امکان را می‌دهد که داده‌ها را به صورت دینامیک ساختاردهی کرده و برای بازگشت پاسخ‌های API از ساختارهای استاندارد و قابل تنظیم استفاده کنید.

## محتوا

- [کلاس‌ها و توابع](#کلاس‌ها-و-توابع)
  - [DynamicDTO](#dynamicdto)
- [نحوه استفاده](#نحوه-استفاده)

---

## کلاس‌ها و توابع

### 1. `DynamicDTO`

کلاس `DynamicDTO` برای نمایش ویژگی‌های داینامیک یک داده استفاده می‌شود. این کلاس می‌تواند برای مدیریت داده‌هایی که خصوصیات آن‌ها ممکن است در زمان اجرا تغییر کنند یا نیاز به تنظیمات خاص دارند، استفاده شود.

#### ویژگی‌ها:

- **`Key (string)`**: کلید یا شناسه‌ای برای ویژگی که به طور دینامیک ایجاد می‌شود.
- **`Name (string)`**: نام یا برچسبی برای ویژگی.
- **`Type (string)`**: نوع داده برای ویژگی. معمولاً این ویژگی برای مشخص کردن نوع داده (مثل `string`, `Number`, `DateTime` و غیره) استفاده می‌شود.
- **`IsHide (bool)`**: مشخص می‌کند که آیا ویژگی باید مخفی شود یا نمایش داده شود.
- **`IsEditable (bool)`**: مشخص می‌کند که آیا ویژگی قابل ویرایش است یا خیر.

#### مثال استفاده:

```csharp
DynamicDTO dynamicData = new DynamicDTO
{
    Key = "stuffTypeName",
    Name = "نوع کالا",
    Type = "Number",
    IsHide = false,
    IsEditable = true
};

// ایجاد یک لیست از داده‌ها
List<InvoiceList_ResultDTO> ListFinalData = GetInvoiceListData(); // این متد باید لیست داده‌ها را بازگشت دهد.

// ایجاد نتیجه API
var result = new ApiResult<List<InvoiceList_ResultDTO>>
{
    Data = ListFinalData,
    IsSuccess = true,
    Message = ResponseCodes.succeed.ToString(),
    ResponseCode = (int)ResponseCodes.succeed
};

// ایجاد ستون‌های دینامیک
var Cols = new DynamicDTO[12];
Cols[0] = new DynamicDTO() { Key = "stuffTypeName", Name = "نوع کالا", Type = "Number", IsHide = false };
Cols[1] = new DynamicDTO() { Key = "stuffTypeId", Name = "StuffTypeId", Type = "Number", IsHide = true };

// اضافه کردن ستون‌ها به جزئیات نتیجه
result.Detail.Add("Columns", Cols);

// برگشت نتیجه
return result;
```
