import {Udomitelj} from "./Udomitelj.js"
import {Zaposleni} from "./Zaposleni.js"
import {Zivotinja} from "./Zivotinja.js"
import {Zivotinja2} from "./Zivotinja2.js"
import {Cip} from "./Cip.js"
import {Cip2} from "./Cip2.js"
import {KartonVakc} from "./KartonVakc.js"

export class Azil
{
    constructor(id, naziv, kontaktTelefon, email, brZaposlenih, brZivotinja) {
        
        this.id = id;
        this.naziv = naziv;
        this.kontaktTelefon = kontaktTelefon;
        this.email = email;
        this.brZaposlenih = brZaposlenih;
        this.brZivotinja = brZivotinja;

        this.kontejner = null;

        this.listaZivotinja=[];
        this.listaZaposlenih=[];
        this.listaUdomitelja=[];
        this.listaCipova=[];
        this.listaKartona=[];
        this.listaDatum=[];

        //select

        this.listaPolova=[];
        this.listaVrsti=[];
        this.listaDatuma=[];
        this.listaImena=[];
    }

    dodajZaposlenog(za) {
       
        this.listaZaposlenih.push(za);
    }
    dodajZivotinju(z){
      
        this.listaZivotinja.push(z);
    }
    dodajUdomitelja(u){
        
        this.listaUdomitelja.push(u);
    }
    dodajCip(c){
        
        this.listaCipova.push(c);
    }
    dodajKarton(k){
        
        this.listaKartona.push(k);
    }

    crtaj(host){

        var l = document.createElement("h2");
        l.innerHTML = this.naziv;
        l.className = "Naslov";
        host.appendChild(l);

        this.kontejner = document.createElement("div");
        this.kontejner.className = "GlavniKont";
        this.kontejner.classList.add("kontejner");
        host.appendChild(this.kontejner);

        let kontForma = document.createElement("div");
        kontForma.className="Forma";
        this.kontejner.appendChild(kontForma);

        this.crtajFormu(kontForma);
        this.crtajPrikaz(kontForma);
    
       // this.crtajPrikaz3(kontForma);
       // this.crtajFormu2(kontForma);

        this.CrtajUdomiZivotinju(kontForma);
        this.CrtajObrisiZaposlenog(kontForma);

        this.crtajDodajCip(kontForma);
        this.CrtajIzmeniKarton(kontForma);
    }

    crtajPrikaz(host){

        let kontPrikaz = document.createElement("div");
        kontPrikaz.className="Prikaz";
        host.appendChild(kontPrikaz);
    
        var tabela = document.createElement("table");
        tabela.className="tabela";
        kontPrikaz.appendChild(tabela);
    
        var tabelahead= document.createElement("thead");
        tabela.appendChild(tabelahead);
    
        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);
    
        var tabelaBody = document.createElement("tbody");
        tabelaBody.className="TabelaPodaci" + this.id;
        tabela.appendChild(tabelaBody);
    
        let th;
        var zag=["Ime", "Starost","Br. cipa", "Br. kartona vakcinacije", "Naziv vakcine", "Datum vakcinacije"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }


    crtajRed(host){
        let red = document.createElement("div");
        red.className="red";
        host.appendChild(red);
        return red;
    }

    crtajFormu(host){
        
        //labela odaberite vrstu
        let red = this.crtajRed(host);
        let l = document.createElement("label");
        l.innerHTML="Odaberite vrstu: ";
        l.className="Odaberi";
        red.appendChild(l);

        //select za vrstu
        let s = document.createElement("select");
        s.className="SelectZaVrstu"
        red.appendChild(s);

        this.listaCipova.forEach(p =>{
            if(!this.listaVrsti.includes(p.vrstaZ))
                this.listaVrsti.push(p.vrstaZ)
        })

        let op;
        this.listaVrsti.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML = p;
            op.value = p;
            s.appendChild(op);
        })

        //labela odaberite pol
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Odaberite pol: ";
        l.className="Odaberi";
        red.appendChild(l);

        //select za pol
        s = document.createElement("select");
        s.className="SelectZaPol"
        red.appendChild(s);

        this.listaCipova.forEach(p =>{
            if(!this.listaPolova.includes(p.polZ))
                this.listaPolova.push(p.polZ)
        })

        this.listaPolova.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML = p;
            op.value = p;
            s.appendChild(op);

        })

        //dugme prikazi zivotinje
        red = this.crtajRed(host);
        let btnPrikaz = document.createElement("button");
        btnPrikaz.onclick=(ev)=>this.nadjiZivotinje();
        btnPrikaz.innerHTML= "Prikazi zivotinje";
        btnPrikaz.className="Dugme";
        red.appendChild(btnPrikaz);

    }

    nadjiZivotinje(){

        let optionEl = this.kontejner.querySelector(".SelectZaVrstu");
        var vrstaID = optionEl.options[optionEl.selectedIndex].value;
        console.log(vrstaID);

        optionEl = this.kontejner.querySelector(".SelectZaPol");
        var polID = optionEl.options[optionEl.selectedIndex].value;
        console.log(polID);

        this.ucitajZivotinje(vrstaID, polID);

    }

    ucitajZivotinje(vrstaID, polID){
    fetch("https://localhost:5001/Zivotinja/PrikaziVrstuPol/"+vrstaID+"/"+polID +"/"+ this.id, //OK
        {
            method:"GET",
        }).then(p=>{
            if(p.ok){
                var teloTabele = this.obrisiPrethodniSadrzaj();
                p.json().then(data=>{
                    var i =0;
                    data.forEach(p=>{
                        console.log(p.imeZ, p.brGodina, p.brCipa, p.brKartonaVakc, p.nazivVakcine, p.datumVakcinacije)
                        let z = new Zivotinja2(p.imeZ, p.brGodina, p.brCipa, p.brKartonaVakc, p.nazivVakcine, p.datumVakcinacije);
                        z.crtajZivotinju(teloTabele, i++);
                    })
                    
                })
            }
        })
    }

    obrisiPrethodniSadrzaj(){
        var teloTabele = document.querySelector(".TabelaPodaci"+ this.id);
        var roditelj = teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaci"+ this.id;
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }

    CrtajUdomiZivotinju(host)
    {
        //unesite Ime
        var red = this.crtajRed(host);
        var l = document.createElement("label");
        l.innerHTML="Ime:";
        red.appendChild(l);
        var ime = document.createElement("input");
        ime.type="string";
        ime.className="KlasaIme";
        red.appendChild(ime);

        //unesite prezime
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Prezime:";
        red.appendChild(l);
        var prezime = document.createElement("input");
        prezime.type="string";
        prezime.className="KlasaPrezime";
        red.appendChild(prezime);

        //unesite adresu
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Adresa:";
        red.appendChild(l);
        var adresa = document.createElement("input");
        adresa.type="string";
        adresa.className="KlasaAdresa";
        red.appendChild(adresa);

        //unesite br telefona
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Br. telefona:";
        red.appendChild(l);
        var brTel = document.createElement("input");
        brTel.type="string";
        brTel.className="KlasaBrTel";
        red.appendChild(brTel);

        //unesite br licne karte
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Br. licne karte:";
        red.appendChild(l);
        var brLK = document.createElement("input");
        brLK.type="string";
        brLK.className="KlasabrLK";
        red.appendChild(brLK);

        //unesite jmbg
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="JMBG:";
        red.appendChild(l);
        var jmbg = document.createElement("input");
        jmbg.type="string";
        jmbg.className="KlasaJMBG";
        red.appendChild(jmbg);

        //unesite broj cipa
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Br. cipa:";
        red.appendChild(l);
        var brCipa = document.createElement("input");
        brCipa.type="string";
        brCipa.className="KlasaBrCipa";
        red.appendChild(brCipa);

        //dugme udomi
        red = this.crtajRed(host);
        let btnUdomi = document.createElement("button");
        btnUdomi.onclick=(ev)=>this.obrisiZivotinju(brCipa.value);
        btnUdomi.innerHTML="Udomite zivotinju";
        btnUdomi.className="Dugme";
        red.appendChild(btnUdomi);
    }

    obrisiZivotinju(cip)
    {
        if(cip===null || cip==="")
        {
            alert("Unesite broj cipa!");
            return;
        }
        
        fetch("https://localhost:5001/Zivotinja/IzbrisiZivotinju/"+cip+"/"+ this.id, //OK
            {
                method:"DELETE"
            }).then(p=>{
                if(p.ok)
                {
                    var teloTabele = this.obrisiPrethodniSadrzaj();
                    this.nadjiZivotinje();

                    console.log("Zivotinja je udomljena!");
                }
                else alert("Ne postoji zivotinja sa unetim brojem cipa!");
                
            })
    }



    CrtajObrisiZaposlenog(host)
    {
        //unos jmbg-a
        let red = this.crtajRed(host);
        let l = document.createElement("label");
        l.innerHTML="JMBG zaposlenog:";
        red.appendChild(l);
        var jmbg = document.createElement("input");
        jmbg.type="string";
        jmbg.className="KlasaJMBG2";
        red.appendChild(jmbg);

        //dugme otpusti
        red = this.crtajRed(host);
        let btnOtpusti = document.createElement("button");
        btnOtpusti.onclick=(ev)=>this.ObrisiZaposlenog(jmbg.value);
        btnOtpusti.innerHTML="Otpusti zaposlenog";
        btnOtpusti.className="Dugme";
        red.appendChild(btnOtpusti);
    }

    ObrisiZaposlenog(jmbg)
    {
        if(jmbg===null || jmbg==="")
        {
            alert("Unesite JMBG!");
            return;
        }
        else
        {
            if(jmbg.length!=13)
            {
                alert("Neispravna vrednost uneta za JMBG!");
                return;
            }
        }
        fetch("https://localhost:5001/Zaposleni/IzbrisiZaposlenog/"+jmbg+"/"+this.id,
        {
            method: "DELETE"
        }).then(p=>{
            if(p.ok)
            {
                var teloTabele = this.obrisiPrethodniSadrzaj();
               // this.nadjiZaposlene();

                console.log("Zaposleni ciji je JMBG: " +jmbg+ "je otpusten.");
            }
            else alert("Ne postoji zaposleni sa unetim JMBG-om!");
        })
    }

    nadjiZaposlene()
    {
        this.ucitajZaposlene();
    }

    ucitajZaposlene()
    {
        fetch("https://localhost:5001/Zaposleni/PrikaziZaposlene/"+this.id,
        {
            method:"GET"
        }).then(p=>{
            if(p.ok){
                var teloTabele = this.obrisiPrethodniSadrzaj();
                p.json().then(data=>{
                    data.forEach(p=>{
                        console.log(p.ime, p.prezime, p.adresa, p.jmbg)
                        let u = new Udomitelj(p.ime, p.prezime, p.adresa, p.jmbg);
                        u.crtaj(teloTabele);
                    })
                })
            }
        })
    }

    crtajDodajCip(host)
    {

          //labela odaberi ime
          let red = this.crtajRed(host);
          let l = document.createElement("label");
          l.innerHTML="Odaberite ime:";
          l.className="Odaberi2";
          red.appendChild(l);
  
          //select za ime
          let s = document.createElement("select");
          s.className="SelectZaIme"
          red.appendChild(s);
  
          console.log(this.listaZivotinja)
          this.listaZivotinja.forEach(p =>{
              if(!this.listaImena.includes(p.imeZ))
                  this.listaImena.push(p.imeZ)
          })
          console.log(this.listaImena)
  
          let op;
          this.listaImena.forEach(p=>{
              op = document.createElement("option");
              op.innerHTML = p;
              op.value = p;
              s.appendChild(op);
          })

        //unesite pol
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Pol:";
        red.appendChild(l);
        var pol = document.createElement("input");
        pol.type="string";
        pol.className="KlasaPol";
        red.appendChild(pol);

        //unesite br godina
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Starost:";
        red.appendChild(l);
        var starost = document.createElement("input");
        starost.type="string";
        starost.className="KlasaStarost";
        red.appendChild(starost);

        //unesite br licne karte
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Vrsta:";
        red.appendChild(l);
        var vrsta = document.createElement("input");
        vrsta.type="string";
        vrsta.className="KlasaVrsta";
        red.appendChild(vrsta);

        //dugme dodaj cip
        red = this.crtajRed(host);
        let btnCip = document.createElement("button");
        btnCip.onclick=(ev)=>this.dodajCipp(pol.value, starost.value, vrsta.value);
        btnCip.innerHTML="Dodaj cip";
        btnCip.className="Dugme";
        red.appendChild(btnCip);
    
        }

    dodajCipp(pol, starost, vrsta)
    {
        if(pol===null || pol ==="")
        {
            alert("Unesite pol!");
            return;
        }

        if(starost===null || starost ==="")
        {
            alert("Unesite starost!");
            return;
        }

        if(vrsta===null || vrsta ==="")
        {
            alert("Unesite vrsta");
            return;
        }

        var optionEl = this.kontejner.querySelector(".SelectZaIme");
        var ime = optionEl.options[optionEl.selectedIndex].value;

        var cip=new Cip2(pol, starost, vrsta, ime)
        console.log(cip)

        fetch("https://localhost:5001/Cip/DodajCip/"+ime+"/"+pol+"/"+starost+"/"+vrsta+"/"+this.id,
        {
            method:"POST",
            headers: {"Content-Type": "application/json"},
            body:JSON.stringify({"polZ":cip.pol,
                                "brGodina":cip.starost,
                                "vrstaZ":cip.vrsta})
        }).then(p=>{
            if(p.ok)
            {
                console.log("uspesno dodat cip");
                this.dodajCip(cip);
            }
            else console.log("neuspesno");
        })
    }

    CrtajIzmeniKarton(host)
    {
        //Unesite ime
        let red = this.crtajRed(host);
        let l = document.createElement("label");
        l.innerHTML="Unesite ime:";
        red.appendChild(l);
        var ime = document.createElement("input");
        ime.type="string";
        ime.className="KlasaImee"
        red.appendChild(ime);

        //Unesite naziv vakcine
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Unesite naziv:";
        red.appendChild(l);
        var naziv = document.createElement("input");
        naziv.type="string";
        naziv.className="KlasaNazivv"
        red.appendChild(naziv);

        //Unesite novi datum
        red = this.crtajRed(host);
        l = document.createElement("label");
        l.innerHTML="Unesite novi datum:";
        l.className="Unesii";
        red.appendChild(l);
    
        var dat = document.createElement("input");
        dat.type="string"
        dat.className="KlasaDatum";
        red.appendChild(dat);

        //Dugme revakcinisi
        red = this.crtajRed(host);
        let btnrevakc = document.createElement("button");
        btnrevakc.onclick=(ev)=>this.izmeniDatum(ime.value, dat.value, naziv.value);
        btnrevakc.innerHTML="Promenite datum";
        btnrevakc.className="Dugme";
        red.appendChild(btnrevakc);
    }

    izmeniDatum(ime, dat, naziv)
    {
        if(ime===null || ime==="")
        {
            alert("Unesite ime!");
            return;
        }
        if(naziv===null || naziv==="")
        {
            alert("Unesite naziv vakcine!");
            return;
        }

        fetch("https://localhost:5001/KartonVakc/Revakcina/"+ime+"/"+dat+"/"+naziv+"/"+this.id,
        {
        method:"PUT",
        }).then(p=>{
        if(p.ok){

            this.nadjiZivotinje;
            console.log("Uspesna revakcinacija"+dat);
        }
        else alert("Neuspesno!");
        }
        )}
    
}