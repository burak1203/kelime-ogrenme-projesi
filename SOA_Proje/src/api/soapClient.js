const soap = require("soap");

const wsdlUrl = "https://tckimlik.nvi.gov.tr/service/kpspublic.asmx?WSDL";

async function validateIdentity(tcNo, firstName, lastName, birthYear) {
    try {
        const client = await soap.createClientAsync(wsdlUrl);
        const args = {
            TCKimlikNo: tcNo,
            Ad: firstName,
            Soyad: lastName,
            DogumYili: birthYear
        };

        const [result] = await client.TCKimlikNoDogrulaAsync(args);
        return result.TCKimlikNoDogrulaResult;
    } catch (error) {
        console.error("SOAP Error:", error);
        throw new Error("SOAP servis hatası!");
    }
}

module.exports = { validateIdentity };
