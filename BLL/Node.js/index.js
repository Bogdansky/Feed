const fs = require("fs");
const request = require("request");

const options = {
    url: "https//ru.wikipedia.org"
}

request(options, (err, res, body) => {
    if (err){
        fs.writeFileSync("res.html", "");
        
        throw err;
    }
})