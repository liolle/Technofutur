const jwt = require('jsonwebtoken');
const fs = require('fs');

const displayHelp = () => {
    console.log("Usage: node jwttool.js --sign --key-file key --payload payload.json --algorithm RS256");
    console.log("-h, --help\t\tDisplay this help message");
    console.log("--sign\t\t\tSign a JWT token");
    console.log("--verify\t\tVerify a JWT token");
    console.log("--read\t\t\tRead a JWT token");
    console.log("--key-file\t\tThe file containing the key");
    console.log("--key\t\t\tThe key");
    console.log("--kid\t\t\tThe kid");
    console.log("--payload\t\tThe file containing the payload");
    console.log("--token\t\t\tThe file containing the token");
    console.log("--algorithm\t\tThe algorithm to use (HS256 or RS256 by default HS256)");
}

// read command line arguments
const args = process.argv.slice(2);
if (args.length < 2) {
    displayHelp();
    return;
}

let key = null;
let payload = null;
let token = null;
let algorithm = "HS256";
let mode = 0;

try
{
    for (let i = 0; i < args.length; i++) {
        switch (args[i]) {
            case "-h":
            case "--help":
                displayHelp();
                return;
            case "--sign":
                mode = 1;
                break;
            case "--verify":
                mode = 2;
                break;
            case "--read":
                mode = 3;
                break;
            case "--key-file":
                key = fs.readFileSync(args[i + 1]);
                i++;
                break;
            case "--key":
                key = args[i + 1];
                i++;
                break;
            case "--kid":
                kid = args[i + 1];
                i++;
                break;
            case "--payload":
                payload = fs.readFileSync(args[i + 1]);
                i++;
                break;
            case "--token":
                token = fs.readFileSync(args[i + 1]);
                i++;
                break;
            case "--algorithm":
                algorithm = args[i + 1];
                i++;
                break;
            default:
                break;
        }
    }
} catch (e) {
    displayHelp();
    console.error(e);
}

const verifyToken = (key, token) => {
    try {
        const decoded = jwt.verify(token, key);
        console.log(decoded);
    } catch (err) {
        console.log(err);
    }
}

const signToken = (key, payload, algorithm) => {
    try {
        let header = {
            "alg": algorithm,
            "typ": "JWT"
        };

        if(kid) {
            header.kid = kid;
        }

        // I don't want it to add iat: to the payload
        const options = {
            header: header,
            algorithm: algorithm,
        };

        const token = jwt.sign(payload, key, options);
        console.log(token);
    } catch (err) {
        console.log(err);
    }
}

const readToken = (token) => {
    try {
        const decoded = jwt.decode(token, {complete: true});
        console.log(decoded);
    } catch (err) {
        console.log(err);
    }
}

switch (mode) {
    case 1:
        signToken(key, payload, algorithm);
        break;
    case 2:
        verifyToken(key, token);
        break;
    case 3:
        readToken(token);
        break;
    default:
        displayHelp();
        break;
}
