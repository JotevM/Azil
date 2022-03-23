import { Azil } from "./Azil.js";
import { Zivotinja } from "./Zivotinja.js";
import { Zaposleni } from "./Zaposleni.js";
import { Udomitelj } from "./Udomitelj.js";
import { Cip } from "./Cip.js";
import { Cip2 } from "./Cip2.js";
import { KartonVakc } from "./KartonVakc.js";

var listaZivotinja=[];
fetch("https://localhost:5001/Zivotinja/PrikaziZivotinju")
    .then(p=>{
        p.json().then(t => {
            t.forEach(tt => {
                var z = new Zivotinja(tt.id, tt.imeZ, tt.brKartonaVakc, tt.brCipa);
                listaZivotinja.push(z);
            })
        })
    })

var listaZaposlenih=[];
fetch("https://localhost:5001/Zaposleni/PrikaziZaposlenog")
    .then(p=>{
        p.json().then(t => {
            t.forEach(tt => {
                var za = new Zaposleni(tt.ime, tt.prezime, tt.adresa, tt.jmbg);
                listaZaposlenih.push(za);
            })
        })
    })

var listaUdomitelja=[];
fetch("https://localhost:5001/Udomitelj/PrikaziUdomitelje")
    .then(p=>{
        p.json().then(t => {
            t.forEach(tt => {
                var u = new Udomitelj(tt.imeU, tt.prezimeU, tt.adresaU, tt.brTelefonaU, tt.brLicneKarte, tt.JMBG);
                listaUdomitelja.push(u);
            })
        })
    })

var listaCipova=[];
fetch("https://localhost:5001/Cip/PrikaziCip")
    .then(p=>{
        p.json().then(t => {
            t.forEach(tt => {
                var c = new Cip(tt.id, tt.polZ, tt.brGodina, tt.vrstaZ);
                listaCipova.push(c);
            })
        })
    })


var listaAzila =[];
fetch("https://localhost:5001/Azil/VratiAzile")
.then(p=>{
    p.json().then(a=>{
        a.forEach(az=> {
            var azil =new Azil(az.id, az.naziv, az.kontaktTelefon, az.email, az.brZaposlenih, az.brZivotinja);
                listaAzila.push(az);
    
                listaZivotinja.forEach(l=>{
                    if(l.id==az.id)
                    console.log(listaZivotinja)
                    azil.dodajZivotinju(l);

                })
    
                listaZaposlenih.forEach(l=>{
                    if(l.id==az.id)
                    azil.dodajZaposlenog(l);
                })
    
                listaUdomitelja.forEach(l=>{
                    if(l.id==az.id)
                    azil.dodajUdomitelja(l);
                })

                listaCipova.forEach(l=>{
                    if(l.id==az.id)
                    console.log(listaCipova)
                    azil.dodajCip(l);
                })

                azil.crtaj(document.body);
            })
    
        }) 
    })
    
    
console.log(listaAzila)