using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class LanguageValidator : IValidator<XCRI.Validation.ContentValidation.LanguageValidator>
    {
        [TestMethod]
        public void TestLanguage_ab() { Assert.IsTrue(this.PassesValidationString("ab")); }
        [TestMethod]
        public void TestLanguage_aa() { Assert.IsTrue(this.PassesValidationString("aa")); }
        [TestMethod]
        public void TestLanguage_af() { Assert.IsTrue(this.PassesValidationString("af")); }
        [TestMethod]
        public void TestLanguage_ak() { Assert.IsTrue(this.PassesValidationString("ak")); }
        [TestMethod]
        public void TestLanguage_sq() { Assert.IsTrue(this.PassesValidationString("sq")); }
        [TestMethod]
        public void TestLanguage_am() { Assert.IsTrue(this.PassesValidationString("am")); }
        [TestMethod]
        public void TestLanguage_ar() { Assert.IsTrue(this.PassesValidationString("ar")); }
        [TestMethod]
        public void TestLanguage_an() { Assert.IsTrue(this.PassesValidationString("an")); }
        [TestMethod]
        public void TestLanguage_hy() { Assert.IsTrue(this.PassesValidationString("hy")); }
        [TestMethod]
        public void TestLanguage_as() { Assert.IsTrue(this.PassesValidationString("as")); }
        [TestMethod]
        public void TestLanguage_av() { Assert.IsTrue(this.PassesValidationString("av")); }
        [TestMethod]
        public void TestLanguage_ae() { Assert.IsTrue(this.PassesValidationString("ae")); }
        [TestMethod]
        public void TestLanguage_ay() { Assert.IsTrue(this.PassesValidationString("ay")); }
        [TestMethod]
        public void TestLanguage_az() { Assert.IsTrue(this.PassesValidationString("az")); }
        [TestMethod]
        public void TestLanguage_bm() { Assert.IsTrue(this.PassesValidationString("bm")); }
        [TestMethod]
        public void TestLanguage_ba() { Assert.IsTrue(this.PassesValidationString("ba")); }
        [TestMethod]
        public void TestLanguage_eu() { Assert.IsTrue(this.PassesValidationString("eu")); }
        [TestMethod]
        public void TestLanguage_be() { Assert.IsTrue(this.PassesValidationString("be")); }
        [TestMethod]
        public void TestLanguage_bn() { Assert.IsTrue(this.PassesValidationString("bn")); }
        [TestMethod]
        public void TestLanguage_bh() { Assert.IsTrue(this.PassesValidationString("bh")); }
        [TestMethod]
        public void TestLanguage_bi() { Assert.IsTrue(this.PassesValidationString("bi")); }
        [TestMethod]
        public void TestLanguage_nb() { Assert.IsTrue(this.PassesValidationString("nb")); }
        [TestMethod]
        public void TestLanguage_bs() { Assert.IsTrue(this.PassesValidationString("bs")); }
        [TestMethod]
        public void TestLanguage_br() { Assert.IsTrue(this.PassesValidationString("br")); }
        [TestMethod]
        public void TestLanguage_bg() { Assert.IsTrue(this.PassesValidationString("bg")); }
        [TestMethod]
        public void TestLanguage_my() { Assert.IsTrue(this.PassesValidationString("my")); }
        [TestMethod]
        public void TestLanguage_es() { Assert.IsTrue(this.PassesValidationString("es")); }
        [TestMethod]
        public void TestLanguage_ca() { Assert.IsTrue(this.PassesValidationString("ca")); }
        [TestMethod]
        public void TestLanguage_km() { Assert.IsTrue(this.PassesValidationString("km")); }
        [TestMethod]
        public void TestLanguage_ch() { Assert.IsTrue(this.PassesValidationString("ch")); }
        [TestMethod]
        public void TestLanguage_ce() { Assert.IsTrue(this.PassesValidationString("ce")); }
        [TestMethod]
        public void TestLanguage_ny() { Assert.IsTrue(this.PassesValidationString("ny")); }
        [TestMethod]
        public void TestLanguage_zh() { Assert.IsTrue(this.PassesValidationString("zh")); }
        [TestMethod]
        public void TestLanguage_za() { Assert.IsTrue(this.PassesValidationString("za")); }
        [TestMethod]
        public void TestLanguage_cu() { Assert.IsTrue(this.PassesValidationString("cu")); }
        [TestMethod]
        public void TestLanguage_cv() { Assert.IsTrue(this.PassesValidationString("cv")); }
        [TestMethod]
        public void TestLanguage_kw() { Assert.IsTrue(this.PassesValidationString("kw")); }
        [TestMethod]
        public void TestLanguage_co() { Assert.IsTrue(this.PassesValidationString("co")); }
        [TestMethod]
        public void TestLanguage_cr() { Assert.IsTrue(this.PassesValidationString("cr")); }
        [TestMethod]
        public void TestLanguage_hr() { Assert.IsTrue(this.PassesValidationString("hr")); }
        [TestMethod]
        public void TestLanguage_cs() { Assert.IsTrue(this.PassesValidationString("cs")); }
        [TestMethod]
        public void TestLanguage_da() { Assert.IsTrue(this.PassesValidationString("da")); }
        [TestMethod]
        public void TestLanguage_dv() { Assert.IsTrue(this.PassesValidationString("dv")); }
        [TestMethod]
        public void TestLanguage_nl() { Assert.IsTrue(this.PassesValidationString("nl")); }
        [TestMethod]
        public void TestLanguage_dz() { Assert.IsTrue(this.PassesValidationString("dz")); }
        [TestMethod]
        public void TestLanguage_en() { Assert.IsTrue(this.PassesValidationString("en")); }
        [TestMethod]
        public void TestLanguage_eo() { Assert.IsTrue(this.PassesValidationString("eo")); }
        [TestMethod]
        public void TestLanguage_et() { Assert.IsTrue(this.PassesValidationString("et")); }
        [TestMethod]
        public void TestLanguage_ee() { Assert.IsTrue(this.PassesValidationString("ee")); }
        [TestMethod]
        public void TestLanguage_fo() { Assert.IsTrue(this.PassesValidationString("fo")); }
        [TestMethod]
        public void TestLanguage_fj() { Assert.IsTrue(this.PassesValidationString("fj")); }
        [TestMethod]
        public void TestLanguage_fi() { Assert.IsTrue(this.PassesValidationString("fi")); }
        [TestMethod]
        public void TestLanguage_fr() { Assert.IsTrue(this.PassesValidationString("fr")); }
        [TestMethod]
        public void TestLanguage_ff() { Assert.IsTrue(this.PassesValidationString("ff")); }
        [TestMethod]
        public void TestLanguage_gd() { Assert.IsTrue(this.PassesValidationString("gd")); }
        [TestMethod]
        public void TestLanguage_gl() { Assert.IsTrue(this.PassesValidationString("gl")); }
        [TestMethod]
        public void TestLanguage_lg() { Assert.IsTrue(this.PassesValidationString("lg")); }
        [TestMethod]
        public void TestLanguage_ka() { Assert.IsTrue(this.PassesValidationString("ka")); }
        [TestMethod]
        public void TestLanguage_de() { Assert.IsTrue(this.PassesValidationString("de")); }
        [TestMethod]
        public void TestLanguage_ki() { Assert.IsTrue(this.PassesValidationString("ki")); }
        [TestMethod]
        public void TestLanguage_el() { Assert.IsTrue(this.PassesValidationString("el")); }
        [TestMethod]
        public void TestLanguage_kl() { Assert.IsTrue(this.PassesValidationString("kl")); }
        [TestMethod]
        public void TestLanguage_gn() { Assert.IsTrue(this.PassesValidationString("gn")); }
        [TestMethod]
        public void TestLanguage_gu() { Assert.IsTrue(this.PassesValidationString("gu")); }
        [TestMethod]
        public void TestLanguage_ht() { Assert.IsTrue(this.PassesValidationString("ht")); }
        [TestMethod]
        public void TestLanguage_ha() { Assert.IsTrue(this.PassesValidationString("ha")); }
        [TestMethod]
        public void TestLanguage_he() { Assert.IsTrue(this.PassesValidationString("he")); }
        [TestMethod]
        public void TestLanguage_hz() { Assert.IsTrue(this.PassesValidationString("hz")); }
        [TestMethod]
        public void TestLanguage_hi() { Assert.IsTrue(this.PassesValidationString("hi")); }
        [TestMethod]
        public void TestLanguage_ho() { Assert.IsTrue(this.PassesValidationString("ho")); }
        [TestMethod]
        public void TestLanguage_hu() { Assert.IsTrue(this.PassesValidationString("hu")); }
        [TestMethod]
        public void TestLanguage_is() { Assert.IsTrue(this.PassesValidationString("is")); }
        [TestMethod]
        public void TestLanguage_io() { Assert.IsTrue(this.PassesValidationString("io")); }
        [TestMethod]
        public void TestLanguage_ig() { Assert.IsTrue(this.PassesValidationString("ig")); }
        [TestMethod]
        public void TestLanguage_id() { Assert.IsTrue(this.PassesValidationString("id")); }
        [TestMethod]
        public void TestLanguage_ia() { Assert.IsTrue(this.PassesValidationString("ia")); }
        [TestMethod]
        public void TestLanguage_ie() { Assert.IsTrue(this.PassesValidationString("ie")); }
        [TestMethod]
        public void TestLanguage_iu() { Assert.IsTrue(this.PassesValidationString("iu")); }
        [TestMethod]
        public void TestLanguage_ik() { Assert.IsTrue(this.PassesValidationString("ik")); }
        [TestMethod]
        public void TestLanguage_ga() { Assert.IsTrue(this.PassesValidationString("ga")); }
        [TestMethod]
        public void TestLanguage_it() { Assert.IsTrue(this.PassesValidationString("it")); }
        [TestMethod]
        public void TestLanguage_ja() { Assert.IsTrue(this.PassesValidationString("ja")); }
        [TestMethod]
        public void TestLanguage_jv() { Assert.IsTrue(this.PassesValidationString("jv")); }
        [TestMethod]
        public void TestLanguage_kn() { Assert.IsTrue(this.PassesValidationString("kn")); }
        [TestMethod]
        public void TestLanguage_kr() { Assert.IsTrue(this.PassesValidationString("kr")); }
        [TestMethod]
        public void TestLanguage_ks() { Assert.IsTrue(this.PassesValidationString("ks")); }
        [TestMethod]
        public void TestLanguage_kk() { Assert.IsTrue(this.PassesValidationString("kk")); }
        [TestMethod]
        public void TestLanguage_rw() { Assert.IsTrue(this.PassesValidationString("rw")); }
        [TestMethod]
        public void TestLanguage_ky() { Assert.IsTrue(this.PassesValidationString("ky")); }
        [TestMethod]
        public void TestLanguage_kv() { Assert.IsTrue(this.PassesValidationString("kv")); }
        [TestMethod]
        public void TestLanguage_kg() { Assert.IsTrue(this.PassesValidationString("kg")); }
        [TestMethod]
        public void TestLanguage_ko() { Assert.IsTrue(this.PassesValidationString("ko")); }
        [TestMethod]
        public void TestLanguage_kj() { Assert.IsTrue(this.PassesValidationString("kj")); }
        [TestMethod]
        public void TestLanguage_ku() { Assert.IsTrue(this.PassesValidationString("ku")); }
        [TestMethod]
        public void TestLanguage_lo() { Assert.IsTrue(this.PassesValidationString("lo")); }
        [TestMethod]
        public void TestLanguage_la() { Assert.IsTrue(this.PassesValidationString("la")); }
        [TestMethod]
        public void TestLanguage_lv() { Assert.IsTrue(this.PassesValidationString("lv")); }
        [TestMethod]
        public void TestLanguage_lb() { Assert.IsTrue(this.PassesValidationString("lb")); }
        [TestMethod]
        public void TestLanguage_li() { Assert.IsTrue(this.PassesValidationString("li")); }
        [TestMethod]
        public void TestLanguage_ln() { Assert.IsTrue(this.PassesValidationString("ln")); }
        [TestMethod]
        public void TestLanguage_lt() { Assert.IsTrue(this.PassesValidationString("lt")); }
        [TestMethod]
        public void TestLanguage_lu() { Assert.IsTrue(this.PassesValidationString("lu")); }
        [TestMethod]
        public void TestLanguage_mk() { Assert.IsTrue(this.PassesValidationString("mk")); }
        [TestMethod]
        public void TestLanguage_mg() { Assert.IsTrue(this.PassesValidationString("mg")); }
        [TestMethod]
        public void TestLanguage_ms() { Assert.IsTrue(this.PassesValidationString("ms")); }
        [TestMethod]
        public void TestLanguage_ml() { Assert.IsTrue(this.PassesValidationString("ml")); }
        [TestMethod]
        public void TestLanguage_mt() { Assert.IsTrue(this.PassesValidationString("mt")); }
        [TestMethod]
        public void TestLanguage_gv() { Assert.IsTrue(this.PassesValidationString("gv")); }
        [TestMethod]
        public void TestLanguage_mi() { Assert.IsTrue(this.PassesValidationString("mi")); }
        [TestMethod]
        public void TestLanguage_mr() { Assert.IsTrue(this.PassesValidationString("mr")); }
        [TestMethod]
        public void TestLanguage_mh() { Assert.IsTrue(this.PassesValidationString("mh")); }
        [TestMethod]
        public void TestLanguage_ro() { Assert.IsTrue(this.PassesValidationString("ro")); }
        [TestMethod]
        public void TestLanguage_mn() { Assert.IsTrue(this.PassesValidationString("mn")); }
        [TestMethod]
        public void TestLanguage_na() { Assert.IsTrue(this.PassesValidationString("na")); }
        [TestMethod]
        public void TestLanguage_nv() { Assert.IsTrue(this.PassesValidationString("nv")); }
        [TestMethod]
        public void TestLanguage_nd() { Assert.IsTrue(this.PassesValidationString("nd")); }
        [TestMethod]
        public void TestLanguage_nr() { Assert.IsTrue(this.PassesValidationString("nr")); }
        [TestMethod]
        public void TestLanguage_ng() { Assert.IsTrue(this.PassesValidationString("ng")); }
        [TestMethod]
        public void TestLanguage_ne() { Assert.IsTrue(this.PassesValidationString("ne")); }
        [TestMethod]
        public void TestLanguage_se() { Assert.IsTrue(this.PassesValidationString("se")); }
        [TestMethod]
        public void TestLanguage_no() { Assert.IsTrue(this.PassesValidationString("no")); }
        [TestMethod]
        public void TestLanguage_nn() { Assert.IsTrue(this.PassesValidationString("nn")); }
        [TestMethod]
        public void TestLanguage_ii() { Assert.IsTrue(this.PassesValidationString("ii")); }
        [TestMethod]
        public void TestLanguage_oc() { Assert.IsTrue(this.PassesValidationString("oc")); }
        [TestMethod]
        public void TestLanguage_oj() { Assert.IsTrue(this.PassesValidationString("oj")); }
        [TestMethod]
        public void TestLanguage_or() { Assert.IsTrue(this.PassesValidationString("or")); }
        [TestMethod]
        public void TestLanguage_om() { Assert.IsTrue(this.PassesValidationString("om")); }
        [TestMethod]
        public void TestLanguage_os() { Assert.IsTrue(this.PassesValidationString("os")); }
        [TestMethod]
        public void TestLanguage_pi() { Assert.IsTrue(this.PassesValidationString("pi")); }
        [TestMethod]
        public void TestLanguage_pa() { Assert.IsTrue(this.PassesValidationString("pa")); }
        [TestMethod]
        public void TestLanguage_ps() { Assert.IsTrue(this.PassesValidationString("ps")); }
        [TestMethod]
        public void TestLanguage_fa() { Assert.IsTrue(this.PassesValidationString("fa")); }
        [TestMethod]
        public void TestLanguage_pl() { Assert.IsTrue(this.PassesValidationString("pl")); }
        [TestMethod]
        public void TestLanguage_pt() { Assert.IsTrue(this.PassesValidationString("pt")); }
        [TestMethod]
        public void TestLanguage_qu() { Assert.IsTrue(this.PassesValidationString("qu")); }
        [TestMethod]
        public void TestLanguage_rm() { Assert.IsTrue(this.PassesValidationString("rm")); }
        [TestMethod]
        public void TestLanguage_rn() { Assert.IsTrue(this.PassesValidationString("rn")); }
        [TestMethod]
        public void TestLanguage_ru() { Assert.IsTrue(this.PassesValidationString("ru")); }
        [TestMethod]
        public void TestLanguage_sm() { Assert.IsTrue(this.PassesValidationString("sm")); }
        [TestMethod]
        public void TestLanguage_sg() { Assert.IsTrue(this.PassesValidationString("sg")); }
        [TestMethod]
        public void TestLanguage_sa() { Assert.IsTrue(this.PassesValidationString("sa")); }
        [TestMethod]
        public void TestLanguage_sc() { Assert.IsTrue(this.PassesValidationString("sc")); }
        [TestMethod]
        public void TestLanguage_sr() { Assert.IsTrue(this.PassesValidationString("sr")); }
        [TestMethod]
        public void TestLanguage_sn() { Assert.IsTrue(this.PassesValidationString("sn")); }
        [TestMethod]
        public void TestLanguage_sd() { Assert.IsTrue(this.PassesValidationString("sd")); }
        [TestMethod]
        public void TestLanguage_si() { Assert.IsTrue(this.PassesValidationString("si")); }
        [TestMethod]
        public void TestLanguage_sk() { Assert.IsTrue(this.PassesValidationString("sk")); }
        [TestMethod]
        public void TestLanguage_sl() { Assert.IsTrue(this.PassesValidationString("sl")); }
        [TestMethod]
        public void TestLanguage_so() { Assert.IsTrue(this.PassesValidationString("so")); }
        [TestMethod]
        public void TestLanguage_st() { Assert.IsTrue(this.PassesValidationString("st")); }
        [TestMethod]
        public void TestLanguage_su() { Assert.IsTrue(this.PassesValidationString("su")); }
        [TestMethod]
        public void TestLanguage_sw() { Assert.IsTrue(this.PassesValidationString("sw")); }
        [TestMethod]
        public void TestLanguage_ss() { Assert.IsTrue(this.PassesValidationString("ss")); }
        [TestMethod]
        public void TestLanguage_sv() { Assert.IsTrue(this.PassesValidationString("sv")); }
        [TestMethod]
        public void TestLanguage_tl() { Assert.IsTrue(this.PassesValidationString("tl")); }
        [TestMethod]
        public void TestLanguage_ty() { Assert.IsTrue(this.PassesValidationString("ty")); }
        [TestMethod]
        public void TestLanguage_tg() { Assert.IsTrue(this.PassesValidationString("tg")); }
        [TestMethod]
        public void TestLanguage_ta() { Assert.IsTrue(this.PassesValidationString("ta")); }
        [TestMethod]
        public void TestLanguage_tt() { Assert.IsTrue(this.PassesValidationString("tt")); }
        [TestMethod]
        public void TestLanguage_te() { Assert.IsTrue(this.PassesValidationString("te")); }
        [TestMethod]
        public void TestLanguage_th() { Assert.IsTrue(this.PassesValidationString("th")); }
        [TestMethod]
        public void TestLanguage_bo() { Assert.IsTrue(this.PassesValidationString("bo")); }
        [TestMethod]
        public void TestLanguage_ti() { Assert.IsTrue(this.PassesValidationString("ti")); }
        [TestMethod]
        public void TestLanguage_to() { Assert.IsTrue(this.PassesValidationString("to")); }
        [TestMethod]
        public void TestLanguage_ts() { Assert.IsTrue(this.PassesValidationString("ts")); }
        [TestMethod]
        public void TestLanguage_tn() { Assert.IsTrue(this.PassesValidationString("tn")); }
        [TestMethod]
        public void TestLanguage_tr() { Assert.IsTrue(this.PassesValidationString("tr")); }
        [TestMethod]
        public void TestLanguage_tk() { Assert.IsTrue(this.PassesValidationString("tk")); }
        [TestMethod]
        public void TestLanguage_tw() { Assert.IsTrue(this.PassesValidationString("tw")); }
        [TestMethod]
        public void TestLanguage_ug() { Assert.IsTrue(this.PassesValidationString("ug")); }
        [TestMethod]
        public void TestLanguage_uk() { Assert.IsTrue(this.PassesValidationString("uk")); }
        [TestMethod]
        public void TestLanguage_ur() { Assert.IsTrue(this.PassesValidationString("ur")); }
        [TestMethod]
        public void TestLanguage_uz() { Assert.IsTrue(this.PassesValidationString("uz")); }
        [TestMethod]
        public void TestLanguage_ve() { Assert.IsTrue(this.PassesValidationString("ve")); }
        [TestMethod]
        public void TestLanguage_vi() { Assert.IsTrue(this.PassesValidationString("vi")); }
        [TestMethod]
        public void TestLanguage_vo() { Assert.IsTrue(this.PassesValidationString("vo")); }
        [TestMethod]
        public void TestLanguage_wa() { Assert.IsTrue(this.PassesValidationString("wa")); }
        [TestMethod]
        public void TestLanguage_cy() { Assert.IsTrue(this.PassesValidationString("cy")); }
        [TestMethod]
        public void TestLanguage_fy() { Assert.IsTrue(this.PassesValidationString("fy")); }
        [TestMethod]
        public void TestLanguage_wo() { Assert.IsTrue(this.PassesValidationString("wo")); }
        [TestMethod]
        public void TestLanguage_xh() { Assert.IsTrue(this.PassesValidationString("xh")); }
        [TestMethod]
        public void TestLanguage_yi() { Assert.IsTrue(this.PassesValidationString("yi")); }
        [TestMethod]
        public void TestLanguage_yo() { Assert.IsTrue(this.PassesValidationString("yo")); }
        [TestMethod]
        public void TestLanguage_zu() { Assert.IsTrue(this.PassesValidationString("zu")); }
    }
}
