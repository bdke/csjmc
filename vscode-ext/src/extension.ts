/* --------------------------------------------------------------------------------------------
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 * ------------------------------------------------------------------------------------------ */
// tslint:disable
"use strict";

import * as path from "path";

import { workspace, ExtensionContext, EventEmitter, Uri, Range } from "vscode";
import {
    LanguageClient,
    LanguageClientOptions,
    ServerOptions,
    Trace
} from "vscode-languageclient/node";

let client: LanguageClient;

export async function activate(context: ExtensionContext) {
    // The server is implemented in node
    let serverExe = "dotnet";
    var serverPath = path.join(__dirname, "..", "..", "..", "JMC", "bin", "Debug", "net9.0", "JMC.dll");
    let serverOptions: ServerOptions = {
        run: {
            command: serverExe,
            args: [serverPath, "server"],
        },
        debug: {
            command: serverExe,
            args: [serverPath, "server"],
        },
    };

    workspace.registerTextDocumentContentProvider("jmc-mcfunc", {
        async provideTextDocumentContent(uri, token) {
            console.log(uri);
            return "";
        },
    })

    // Options to control the language client
    let clientOptions: LanguageClientOptions = {
        // Register the server for plain text documents
        documentSelector: [
            {
                pattern: "**/*.jmc",
                language: "jmc",
                scheme: "file"
            },
            {
                pattern: "**/*.hjmc",
                language: "hjmc",
                scheme: "file"
            }
        ],
        outputChannelName: "JMC Language Server",
        progressOnInitialization: true,
        diagnosticPullOptions: {
            onChange: true,

        },
        synchronize: {
            // Synchronize the setting section 'languageServerExample' to the server
            configurationSection: "jmc",
            fileEvents: workspace.createFileSystemWatcher("**/*.jmc"),
        },
    };
    // Create the language client and start the client.
    client = new LanguageClient("jmcClient", "JMC Language Server", serverOptions, clientOptions);
    client.registerProposedFeatures();
    client.setTrace(Trace.Verbose);
    await client.start();
}

export function deactivate() {
    return client.stop();
}
