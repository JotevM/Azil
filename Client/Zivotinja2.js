export class Zivotinja2
{
    constructor(imeZ, starost, brCipa, brKartonaVakc, nazivVakcine, datumVakcinacije) {
       
        this.imeZ = imeZ;
        this.starost = starost;
        this.brKartonaVakc = brKartonaVakc;
        this.brCipa = brCipa;
        this.nazivVakcine = nazivVakcine;
        this.datumVakcinacije = datumVakcinacije;
    }

    crtajZivotinju(host, i){

        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.imeZ;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.starost;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.brCipa;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.brKartonaVakc;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.nazivVakcine;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.datumVakcinacije;
        tr.appendChild(el);
    }
    
}