const fs = require("fs");
const request = require("request");
const log4js = require("log4js");

log4js.configure({ // configure to use all types in different files.
    appenders: {
        error: {
            type: 'file',
            filename: "/logs/error.log", // specify the path where u want logs folder error.log
            category: 'error',
            maxLogSize: 20480,
            backups: 10
        },
        info: {
            type: "file",
            filename: "/logs/info.log", // specify the path where u want logs folder info.log
            category: 'info',
            maxLogSize: 20480,
            backups: 10
        },
        debug: {
            type: "stdout"
        }
    },
    categories: {
        default: {
            appenders: ["debug"],
            level: "debug"
        },
        error: {
            appenders: ["error"],
            level: "error"
        },
        info: {
            appenders: ["info"],
            level: "info"
        }
    }
});

const loggerInfo = log4js.getLogger('info');
const loggerError = log4js.getLogger('error');

const resPath = "res.html"

const options = {
    url: process.argv[2] || "https://ru.wikipedia.org/wiki/%D0%97%D0%B0%D0%B3%D0%BB%D0%B0%D0%B2%D0%BD%D0%B0%D1%8F_%D1%81%D1%82%D1%80%D0%B0%D0%BD%D0%B8%D1%86%D0%B0"
}

request(options, (err, res, body) => {
    if (err){
        fs.writeFileSync(resPath, "");
        loggerError.error(err.message);
        throw err;
    }
    loggerInfo.info(`${res.statusCode} - ${res.statusMessage}`);
    try {
        fs.writeFileSync(resPath, body);
        if (body) {
            loggerInfo.info("Data was written");
        }
    }
    catch (e) {
        loggerError.error(err.message);
        throw err;
    }
})