const express = require("express");
const { validateIdentity } = require("./soapClient");
const cors = require("cors");
const app = express();
app.use(express.json());
app.use(cors());

app.post("/validate", async (req, res) => {
    const { tcNo, firstName, lastName, birthYear } = req.body;

    if (!tcNo || !firstName || !lastName || !birthYear) {
        return res.status(400).json({ error: "Tüm alanlar zorunludur!" });
    }

    try {
        const isValid = await validateIdentity(tcNo, firstName, lastName, birthYear);
        res.json({ isValid });
    } catch (error) {
        res.status(500).json({ error: "Servis hatası!" });
    }
});

const PORT = 3000;
app.listen(PORT, () => {
    console.log(`API çalışıyor: http://localhost:${PORT}`);

});