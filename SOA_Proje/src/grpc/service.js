const grpc = require("@grpc/grpc-js");
const protoLoader = require("@grpc/proto-loader");
const { validateIdentity } = require("../api/soapClient");

const PROTO_PATH = __dirname + "/service.proto";

// Proto dosyasını yükle
const packageDefinition = protoLoader.loadSync(PROTO_PATH, {
    keepCase: true, // Protodaki isimlendirme ile eşleşmesi için
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true,
});

const identityProto = grpc.loadPackageDefinition(packageDefinition).IdentityService;

function validateIdentityGrpc(call, callback) {
    const { tcNo, firstName, lastName, birthYear } = call.request;

    validateIdentity(tcNo, firstName, lastName, birthYear)
        .then((isValid) => callback(null, { isValid }))
        .catch((error) => callback(error));
}

const server = new grpc.Server();
server.addService(identityProto.service, { ValidateIdentity: validateIdentityGrpc });

server.bindAsync(
    "127.0.0.1:50051",
    grpc.ServerCredentials.createInsecure(),
    (err, port) => {
        if (err) return console.error(err);
        console.log(`gRPC server running on port ${port}`);
        server.start();
    }
);
