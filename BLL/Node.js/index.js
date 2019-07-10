const fs = require("fs");
const request = require("request");
const log4js = require("log4js");

log4js.configure({ // configure to use all types in different files.
    appenders: [
        {   type: 'file',
            filename: "/logs/error.log", // specify the path where u want logs folder error.log
            category: 'error',
            maxLogSize: 20480,
            backups: 10
        },
        {   type: "file",
            filename: "/logs/info.log", // specify the path where u want logs folder info.log
            category: 'info',
            maxLogSize: 20480,
            backups: 10
        }
    ]
});

const loggerInfo = log4js.getLogger('info');
const loggerError = log4js.getLogger('error');

const resPath = "res.html"

const options = {
    url: "https://ru.wikipedia.org/wiki/%D0%97%D0%B0%D0%B3%D0%BB%D0%B0%D0%B2%D0%BD%D0%B0%D1%8F_%D1%81%D1%82%D1%80%D0%B0%D0%BD%D0%B8%D1%86%D0%B0"
}

request(options, (err, res, body) => {
    if (err){
        fs.writeFileSync(resPath, "");
        loggerError.info(err.message);
        throw err;
    }
    loggerInfo.info(`${res.statusCode} - ${res.statusMessage}`);
    fs.writeFile(resPath, body, (err) => {
        if (err){
            loggerError.info(err.message);
            throw err;
        }
        if (body){
            loggerInfo.info("Data was written");
        }
    })
})