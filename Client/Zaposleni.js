export class Zaposleni
{
    constructor(ime, prezime, adresa, jmbg){
        this.ime = ime;
        this.prezime = prezime;
        this.adresa = adresa;
        this.jmbg = jmbg;
    }

    crtajZaposlene(host, i){

        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.ime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.prezime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.adresa;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.jmbg;
        tr.appendChild(el);
    }
}