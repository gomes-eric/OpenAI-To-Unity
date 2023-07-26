using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenAIToUnity.Domain.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Language
    {
        [EnumMember(Value = "aa")] Afar,
        [EnumMember(Value = "ab")] Abkhazian,
        [EnumMember(Value = "ae")] Avestan,
        [EnumMember(Value = "af")] Afrikaans,
        [EnumMember(Value = "ak")] Akan,
        [EnumMember(Value = "am")] Amharic,
        [EnumMember(Value = "an")] Aragonese,
        [EnumMember(Value = "ar")] Arabic,
        [EnumMember(Value = "as")] Assamese,
        [EnumMember(Value = "av")] Avaric,
        [EnumMember(Value = "ay")] Aymara,
        [EnumMember(Value = "az")] Azerbaijani,
        [EnumMember(Value = "ba")] Bashkir,
        [EnumMember(Value = "be")] Belarusian,
        [EnumMember(Value = "bg")] Bulgarian,
        [EnumMember(Value = "bh")] Bihari,
        [EnumMember(Value = "bi")] Bislama,
        [EnumMember(Value = "bm")] Bambara,
        [EnumMember(Value = "bn")] Bengali,
        [EnumMember(Value = "bo")] Tibetan,
        [EnumMember(Value = "br")] Breton,
        [EnumMember(Value = "bs")] Bosnian,
        [EnumMember(Value = "ca")] Catalan,
        [EnumMember(Value = "ce")] Chechen,
        [EnumMember(Value = "ch")] Chamorro,
        [EnumMember(Value = "co")] Corsican,
        [EnumMember(Value = "cr")] Cree,
        [EnumMember(Value = "cs")] Czech,
        [EnumMember(Value = "cu")] ChurchSlavic,
        [EnumMember(Value = "cv")] Chuvash,
        [EnumMember(Value = "cy")] Welsh,
        [EnumMember(Value = "da")] Danish,
        [EnumMember(Value = "de")] German,
        [EnumMember(Value = "dv")] Divehi,
        [EnumMember(Value = "dz")] Dzongkha,
        [EnumMember(Value = "ee")] Ewe,
        [EnumMember(Value = "el")] Greek,
        [EnumMember(Value = "en")] English,
        [EnumMember(Value = "eo")] Esperanto,
        [EnumMember(Value = "es")] Spanish,
        [EnumMember(Value = "et")] Estonian,
        [EnumMember(Value = "eu")] Basque,
        [EnumMember(Value = "fa")] Persian,
        [EnumMember(Value = "ff")] Fulah,
        [EnumMember(Value = "fi")] Finnish,
        [EnumMember(Value = "fj")] Fijian,
        [EnumMember(Value = "fo")] Faroese,
        [EnumMember(Value = "fr")] French,
        [EnumMember(Value = "fy")] WesternFrisian,
        [EnumMember(Value = "ga")] Irish,
        [EnumMember(Value = "gd")] ScottishGaelic,
        [EnumMember(Value = "gl")] Galician,
        [EnumMember(Value = "gn")] Guarani,
        [EnumMember(Value = "gu")] Gujarati,
        [EnumMember(Value = "gv")] Manx,
        [EnumMember(Value = "ha")] Hausa,
        [EnumMember(Value = "he")] Hebrew,
        [EnumMember(Value = "hi")] Hindi,
        [EnumMember(Value = "ho")] HiriMotu,
        [EnumMember(Value = "hr")] Croatian,
        [EnumMember(Value = "ht")] Haitian,
        [EnumMember(Value = "hu")] Hungarian,
        [EnumMember(Value = "hy")] Armenian,
        [EnumMember(Value = "hz")] Herero,
        [EnumMember(Value = "ia")] Interlingua,
        [EnumMember(Value = "id")] Indonesian,
        [EnumMember(Value = "ie")] Interlingue,
        [EnumMember(Value = "ig")] Igbo,
        [EnumMember(Value = "ii")] SichuanYi,
        [EnumMember(Value = "ik")] Inupiaq,
        [EnumMember(Value = "io")] Ido,
        [EnumMember(Value = "is")] Icelandic,
        [EnumMember(Value = "it")] Italian,
        [EnumMember(Value = "iu")] Inuktitut,
        [EnumMember(Value = "ja")] Japanese,
        [EnumMember(Value = "jv")] Javanese,
        [EnumMember(Value = "ka")] Georgian,
        [EnumMember(Value = "kg")] Kongo,
        [EnumMember(Value = "ki")] Kikuyu,
        [EnumMember(Value = "kj")] Kuanyama,
        [EnumMember(Value = "kk")] Kazakh,
        [EnumMember(Value = "kl")] Kalaallisut,
        [EnumMember(Value = "km")] Khmer,
        [EnumMember(Value = "kn")] Kannada,
        [EnumMember(Value = "ko")] Korean,
        [EnumMember(Value = "kr")] Kanuri,
        [EnumMember(Value = "ks")] Kashmiri,
        [EnumMember(Value = "ku")] Kurdish,
        [EnumMember(Value = "kv")] Komi,
        [EnumMember(Value = "kw")] Cornish,
        [EnumMember(Value = "ky")] Kirghiz,
        [EnumMember(Value = "la")] Latin,
        [EnumMember(Value = "lb")] Luxembourgish,
        [EnumMember(Value = "lg")] Ganda,
        [EnumMember(Value = "li")] Limburgish,
        [EnumMember(Value = "ln")] Lingala,
        [EnumMember(Value = "lo")] Lao,
        [EnumMember(Value = "lt")] Lithuanian,
        [EnumMember(Value = "lu")] LubaKatanga,
        [EnumMember(Value = "lv")] Latvian,
        [EnumMember(Value = "mg")] Malagasy,
        [EnumMember(Value = "mh")] Marshallese,
        [EnumMember(Value = "mi")] Maori,
        [EnumMember(Value = "mk")] Macedonian,
        [EnumMember(Value = "ml")] Malayalam,
        [EnumMember(Value = "mn")] Mongolian,
        [EnumMember(Value = "mr")] Marathi,
        [EnumMember(Value = "ms")] Malay,
        [EnumMember(Value = "mt")] Maltese,
        [EnumMember(Value = "my")] Burmese,
        [EnumMember(Value = "na")] Nauru,
        [EnumMember(Value = "nb")] NorwegianBokmal,
        [EnumMember(Value = "nd")] NorthNdebele,
        [EnumMember(Value = "ne")] Nepali,
        [EnumMember(Value = "ng")] Ndonga,
        [EnumMember(Value = "nl")] Dutch,
        [EnumMember(Value = "nn")] NorwegianNynorsk,
        [EnumMember(Value = "no")] Norwegian,
        [EnumMember(Value = "nr")] SouthNdebele,
        [EnumMember(Value = "nv")] Navajo,
        [EnumMember(Value = "ny")] Chichewa,
        [EnumMember(Value = "oc")] Occitan,
        [EnumMember(Value = "oj")] Ojibwa,
        [EnumMember(Value = "om")] Oromo,
        [EnumMember(Value = "or")] Oriya,
        [EnumMember(Value = "os")] Ossetian,
        [EnumMember(Value = "pa")] Panjabi,
        [EnumMember(Value = "pi")] Pali,
        [EnumMember(Value = "pl")] Polish,
        [EnumMember(Value = "ps")] Pashto,
        [EnumMember(Value = "pt")] Portuguese,
        [EnumMember(Value = "qu")] Quechua,
        [EnumMember(Value = "rm")] RaetoRomance,
        [EnumMember(Value = "rn")] Kirundi,
        [EnumMember(Value = "ro")] Romanian,
        [EnumMember(Value = "ru")] Russian,
        [EnumMember(Value = "rw")] Kinyarwanda,
        [EnumMember(Value = "sa")] Sanskrit,
        [EnumMember(Value = "sc")] Sardinian,
        [EnumMember(Value = "sd")] Sindhi,
        [EnumMember(Value = "se")] NorthernSami,
        [EnumMember(Value = "sg")] Sango,
        [EnumMember(Value = "si")] Sinhalese,
        [EnumMember(Value = "sk")] Slovak,
        [EnumMember(Value = "sl")] Slovenian,
        [EnumMember(Value = "sm")] Samoan,
        [EnumMember(Value = "sn")] Shona,
        [EnumMember(Value = "so")] Somali,
        [EnumMember(Value = "sq")] Albanian,
        [EnumMember(Value = "sr")] Serbian,
        [EnumMember(Value = "ss")] Swati,
        [EnumMember(Value = "st")] SouthernSotho,
        [EnumMember(Value = "su")] Sundanese,
        [EnumMember(Value = "sv")] Swedish,
        [EnumMember(Value = "sw")] Swahili,
        [EnumMember(Value = "ta")] Tamil,
        [EnumMember(Value = "te")] Telugu,
        [EnumMember(Value = "tg")] Tajik,
        [EnumMember(Value = "th")] Thai,
        [EnumMember(Value = "ti")] Tigrinya,
        [EnumMember(Value = "tk")] Turkmen,
        [EnumMember(Value = "tl")] Tagalog,
        [EnumMember(Value = "tn")] Tswana,
        [EnumMember(Value = "to")] Tonga,
        [EnumMember(Value = "tr")] Turkish,
        [EnumMember(Value = "ts")] Tsonga,
        [EnumMember(Value = "tt")] Tatar,
        [EnumMember(Value = "tw")] Twi,
        [EnumMember(Value = "ty")] Tahitian,
        [EnumMember(Value = "ug")] Uighur,
        [EnumMember(Value = "uk")] Ukrainian,
        [EnumMember(Value = "ur")] Urdu,
        [EnumMember(Value = "uz")] Uzbek,
        [EnumMember(Value = "ve")] Venda,
        [EnumMember(Value = "vi")] Vietnamese,
        [EnumMember(Value = "vo")] Volapuk,
        [EnumMember(Value = "wa")] Walloon,
        [EnumMember(Value = "wo")] Wolof,
        [EnumMember(Value = "xh")] Xhosa,
        [EnumMember(Value = "yi")] Yiddish,
        [EnumMember(Value = "yo")] Yoruba,
        [EnumMember(Value = "za")] Zhuang,
        [EnumMember(Value = "zh")] Chinese,
        [EnumMember(Value = "zu")] Zulu
    }
}