using Microsoft.EntityFrameworkCore.Migrations;

namespace AGooday.Retail.BookStore.Migrations
{
    public partial class Reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BsApiResourceClaims_BsApiResources_ApiResourceId",
                table: "BsApiResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_BsApiResourceProperties_BsApiResources_ApiResourceId",
                table: "BsApiResourceProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_BsApiResourceScopes_BsApiResources_ApiResourceId",
                table: "BsApiResourceScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_BsApiResourceSecrets_BsApiResources_ApiResourceId",
                table: "BsApiResourceSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_BsApiScopeClaims_BsApiScopes_ApiScopeId",
                table: "BsApiScopeClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_BsApiScopeProperties_BsApiScopes_ApiScopeId",
                table: "BsApiScopeProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientClaims_BsClients_ClientId",
                table: "BsClientClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientCorsOrigins_BsClients_ClientId",
                table: "BsClientCorsOrigins");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientGrantTypes_BsClients_ClientId",
                table: "BsClientGrantTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientIdPRestrictions_BsClients_ClientId",
                table: "BsClientIdPRestrictions");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientPostLogoutRedirectUris_BsClients_ClientId",
                table: "BsClientPostLogoutRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientProperties_BsClients_ClientId",
                table: "BsClientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientRedirectUris_BsClients_ClientId",
                table: "BsClientRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientScopes_BsClients_ClientId",
                table: "BsClientScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_BsClientSecrets_BsClients_ClientId",
                table: "BsClientSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_BsIdentityResourceClaims_BsIdentityResources_IdentityResourceId",
                table: "BsIdentityResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_BsIdentityResourceProperties_BsIdentityResources_IdentityResourceId",
                table: "BsIdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsPersistedGrants",
                table: "BsPersistedGrants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsIdentityResources",
                table: "BsIdentityResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsIdentityResourceProperties",
                table: "BsIdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsIdentityResourceClaims",
                table: "BsIdentityResourceClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsDeviceFlowCodes",
                table: "BsDeviceFlowCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientSecrets",
                table: "BsClientSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientScopes",
                table: "BsClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClients",
                table: "BsClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientRedirectUris",
                table: "BsClientRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientProperties",
                table: "BsClientProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientPostLogoutRedirectUris",
                table: "BsClientPostLogoutRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientIdPRestrictions",
                table: "BsClientIdPRestrictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientGrantTypes",
                table: "BsClientGrantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientCorsOrigins",
                table: "BsClientCorsOrigins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsClientClaims",
                table: "BsClientClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsApiScopes",
                table: "BsApiScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsApiScopeProperties",
                table: "BsApiScopeProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsApiScopeClaims",
                table: "BsApiScopeClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsApiResourceSecrets",
                table: "BsApiResourceSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsApiResourceScopes",
                table: "BsApiResourceScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsApiResources",
                table: "BsApiResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsApiResourceProperties",
                table: "BsApiResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BsApiResourceClaims",
                table: "BsApiResourceClaims");

            migrationBuilder.RenameTable(
                name: "BsPersistedGrants",
                newName: "IdentityServerPersistedGrants");

            migrationBuilder.RenameTable(
                name: "BsIdentityResources",
                newName: "IdentityServerIdentityResources");

            migrationBuilder.RenameTable(
                name: "BsIdentityResourceProperties",
                newName: "IdentityServerIdentityResourceProperties");

            migrationBuilder.RenameTable(
                name: "BsIdentityResourceClaims",
                newName: "IdentityServerIdentityResourceClaims");

            migrationBuilder.RenameTable(
                name: "BsDeviceFlowCodes",
                newName: "IdentityServerDeviceFlowCodes");

            migrationBuilder.RenameTable(
                name: "BsClientSecrets",
                newName: "IdentityServerClientSecrets");

            migrationBuilder.RenameTable(
                name: "BsClientScopes",
                newName: "IdentityServerClientScopes");

            migrationBuilder.RenameTable(
                name: "BsClients",
                newName: "IdentityServerClients");

            migrationBuilder.RenameTable(
                name: "BsClientRedirectUris",
                newName: "IdentityServerClientRedirectUris");

            migrationBuilder.RenameTable(
                name: "BsClientProperties",
                newName: "IdentityServerClientProperties");

            migrationBuilder.RenameTable(
                name: "BsClientPostLogoutRedirectUris",
                newName: "IdentityServerClientPostLogoutRedirectUris");

            migrationBuilder.RenameTable(
                name: "BsClientIdPRestrictions",
                newName: "IdentityServerClientIdPRestrictions");

            migrationBuilder.RenameTable(
                name: "BsClientGrantTypes",
                newName: "IdentityServerClientGrantTypes");

            migrationBuilder.RenameTable(
                name: "BsClientCorsOrigins",
                newName: "IdentityServerClientCorsOrigins");

            migrationBuilder.RenameTable(
                name: "BsClientClaims",
                newName: "IdentityServerClientClaims");

            migrationBuilder.RenameTable(
                name: "BsApiScopes",
                newName: "IdentityServerApiScopes");

            migrationBuilder.RenameTable(
                name: "BsApiScopeProperties",
                newName: "IdentityServerApiScopeProperties");

            migrationBuilder.RenameTable(
                name: "BsApiScopeClaims",
                newName: "IdentityServerApiScopeClaims");

            migrationBuilder.RenameTable(
                name: "BsApiResourceSecrets",
                newName: "IdentityServerApiResourceSecrets");

            migrationBuilder.RenameTable(
                name: "BsApiResourceScopes",
                newName: "IdentityServerApiResourceScopes");

            migrationBuilder.RenameTable(
                name: "BsApiResources",
                newName: "IdentityServerApiResources");

            migrationBuilder.RenameTable(
                name: "BsApiResourceProperties",
                newName: "IdentityServerApiResourceProperties");

            migrationBuilder.RenameTable(
                name: "BsApiResourceClaims",
                newName: "IdentityServerApiResourceClaims");

            migrationBuilder.RenameIndex(
                name: "IX_BsPersistedGrants_SubjectId_SessionId_Type",
                table: "IdentityServerPersistedGrants",
                newName: "IX_IdentityServerPersistedGrants_SubjectId_SessionId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_BsPersistedGrants_SubjectId_ClientId_Type",
                table: "IdentityServerPersistedGrants",
                newName: "IX_IdentityServerPersistedGrants_SubjectId_ClientId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_BsPersistedGrants_Expiration",
                table: "IdentityServerPersistedGrants",
                newName: "IX_IdentityServerPersistedGrants_Expiration");

            migrationBuilder.RenameIndex(
                name: "IX_BsDeviceFlowCodes_UserCode",
                table: "IdentityServerDeviceFlowCodes",
                newName: "IX_IdentityServerDeviceFlowCodes_UserCode");

            migrationBuilder.RenameIndex(
                name: "IX_BsDeviceFlowCodes_Expiration",
                table: "IdentityServerDeviceFlowCodes",
                newName: "IX_IdentityServerDeviceFlowCodes_Expiration");

            migrationBuilder.RenameIndex(
                name: "IX_BsDeviceFlowCodes_DeviceCode",
                table: "IdentityServerDeviceFlowCodes",
                newName: "IX_IdentityServerDeviceFlowCodes_DeviceCode");

            migrationBuilder.RenameIndex(
                name: "IX_BsClients_ClientId",
                table: "IdentityServerClients",
                newName: "IX_IdentityServerClients_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerPersistedGrants",
                table: "IdentityServerPersistedGrants",
                column: "Key");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerIdentityResources",
                table: "IdentityServerIdentityResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerIdentityResourceProperties",
                table: "IdentityServerIdentityResourceProperties",
                columns: new[] { "IdentityResourceId", "Key", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerIdentityResourceClaims",
                table: "IdentityServerIdentityResourceClaims",
                columns: new[] { "IdentityResourceId", "Type" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerDeviceFlowCodes",
                table: "IdentityServerDeviceFlowCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientSecrets",
                table: "IdentityServerClientSecrets",
                columns: new[] { "ClientId", "Type", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientScopes",
                table: "IdentityServerClientScopes",
                columns: new[] { "ClientId", "Scope" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClients",
                table: "IdentityServerClients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientRedirectUris",
                table: "IdentityServerClientRedirectUris",
                columns: new[] { "ClientId", "RedirectUri" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientProperties",
                table: "IdentityServerClientProperties",
                columns: new[] { "ClientId", "Key", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientPostLogoutRedirectUris",
                table: "IdentityServerClientPostLogoutRedirectUris",
                columns: new[] { "ClientId", "PostLogoutRedirectUri" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientIdPRestrictions",
                table: "IdentityServerClientIdPRestrictions",
                columns: new[] { "ClientId", "Provider" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientGrantTypes",
                table: "IdentityServerClientGrantTypes",
                columns: new[] { "ClientId", "GrantType" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientCorsOrigins",
                table: "IdentityServerClientCorsOrigins",
                columns: new[] { "ClientId", "Origin" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerClientClaims",
                table: "IdentityServerClientClaims",
                columns: new[] { "ClientId", "Type", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerApiScopes",
                table: "IdentityServerApiScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerApiScopeProperties",
                table: "IdentityServerApiScopeProperties",
                columns: new[] { "ApiScopeId", "Key", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerApiScopeClaims",
                table: "IdentityServerApiScopeClaims",
                columns: new[] { "ApiScopeId", "Type" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerApiResourceSecrets",
                table: "IdentityServerApiResourceSecrets",
                columns: new[] { "ApiResourceId", "Type", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerApiResourceScopes",
                table: "IdentityServerApiResourceScopes",
                columns: new[] { "ApiResourceId", "Scope" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerApiResources",
                table: "IdentityServerApiResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerApiResourceProperties",
                table: "IdentityServerApiResourceProperties",
                columns: new[] { "ApiResourceId", "Key", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityServerApiResourceClaims",
                table: "IdentityServerApiResourceClaims",
                columns: new[] { "ApiResourceId", "Type" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerApiResourceClaims_IdentityServerApiResources_ApiResourceId",
                table: "IdentityServerApiResourceClaims",
                column: "ApiResourceId",
                principalTable: "IdentityServerApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerApiResourceProperties_IdentityServerApiResources_ApiResourceId",
                table: "IdentityServerApiResourceProperties",
                column: "ApiResourceId",
                principalTable: "IdentityServerApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerApiResourceScopes_IdentityServerApiResources_ApiResourceId",
                table: "IdentityServerApiResourceScopes",
                column: "ApiResourceId",
                principalTable: "IdentityServerApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerApiResourceSecrets_IdentityServerApiResources_ApiResourceId",
                table: "IdentityServerApiResourceSecrets",
                column: "ApiResourceId",
                principalTable: "IdentityServerApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerApiScopeClaims_IdentityServerApiScopes_ApiScopeId",
                table: "IdentityServerApiScopeClaims",
                column: "ApiScopeId",
                principalTable: "IdentityServerApiScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerApiScopeProperties_IdentityServerApiScopes_ApiScopeId",
                table: "IdentityServerApiScopeProperties",
                column: "ApiScopeId",
                principalTable: "IdentityServerApiScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientClaims_IdentityServerClients_ClientId",
                table: "IdentityServerClientClaims",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientCorsOrigins_IdentityServerClients_ClientId",
                table: "IdentityServerClientCorsOrigins",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientGrantTypes_IdentityServerClients_ClientId",
                table: "IdentityServerClientGrantTypes",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientIdPRestrictions_IdentityServerClients_ClientId",
                table: "IdentityServerClientIdPRestrictions",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientPostLogoutRedirectUris_IdentityServerClients_ClientId",
                table: "IdentityServerClientPostLogoutRedirectUris",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientProperties_IdentityServerClients_ClientId",
                table: "IdentityServerClientProperties",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientRedirectUris_IdentityServerClients_ClientId",
                table: "IdentityServerClientRedirectUris",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientScopes_IdentityServerClients_ClientId",
                table: "IdentityServerClientScopes",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerClientSecrets_IdentityServerClients_ClientId",
                table: "IdentityServerClientSecrets",
                column: "ClientId",
                principalTable: "IdentityServerClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerIdentityResourceClaims_IdentityServerIdentityResources_IdentityResourceId",
                table: "IdentityServerIdentityResourceClaims",
                column: "IdentityResourceId",
                principalTable: "IdentityServerIdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityServerIdentityResourceProperties_IdentityServerIdentityResources_IdentityResourceId",
                table: "IdentityServerIdentityResourceProperties",
                column: "IdentityResourceId",
                principalTable: "IdentityServerIdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerApiResourceClaims_IdentityServerApiResources_ApiResourceId",
                table: "IdentityServerApiResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerApiResourceProperties_IdentityServerApiResources_ApiResourceId",
                table: "IdentityServerApiResourceProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerApiResourceScopes_IdentityServerApiResources_ApiResourceId",
                table: "IdentityServerApiResourceScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerApiResourceSecrets_IdentityServerApiResources_ApiResourceId",
                table: "IdentityServerApiResourceSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerApiScopeClaims_IdentityServerApiScopes_ApiScopeId",
                table: "IdentityServerApiScopeClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerApiScopeProperties_IdentityServerApiScopes_ApiScopeId",
                table: "IdentityServerApiScopeProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientClaims_IdentityServerClients_ClientId",
                table: "IdentityServerClientClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientCorsOrigins_IdentityServerClients_ClientId",
                table: "IdentityServerClientCorsOrigins");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientGrantTypes_IdentityServerClients_ClientId",
                table: "IdentityServerClientGrantTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientIdPRestrictions_IdentityServerClients_ClientId",
                table: "IdentityServerClientIdPRestrictions");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientPostLogoutRedirectUris_IdentityServerClients_ClientId",
                table: "IdentityServerClientPostLogoutRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientProperties_IdentityServerClients_ClientId",
                table: "IdentityServerClientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientRedirectUris_IdentityServerClients_ClientId",
                table: "IdentityServerClientRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientScopes_IdentityServerClients_ClientId",
                table: "IdentityServerClientScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerClientSecrets_IdentityServerClients_ClientId",
                table: "IdentityServerClientSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerIdentityResourceClaims_IdentityServerIdentityResources_IdentityResourceId",
                table: "IdentityServerIdentityResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityServerIdentityResourceProperties_IdentityServerIdentityResources_IdentityResourceId",
                table: "IdentityServerIdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerPersistedGrants",
                table: "IdentityServerPersistedGrants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerIdentityResources",
                table: "IdentityServerIdentityResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerIdentityResourceProperties",
                table: "IdentityServerIdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerIdentityResourceClaims",
                table: "IdentityServerIdentityResourceClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerDeviceFlowCodes",
                table: "IdentityServerDeviceFlowCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientSecrets",
                table: "IdentityServerClientSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientScopes",
                table: "IdentityServerClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClients",
                table: "IdentityServerClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientRedirectUris",
                table: "IdentityServerClientRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientProperties",
                table: "IdentityServerClientProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientPostLogoutRedirectUris",
                table: "IdentityServerClientPostLogoutRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientIdPRestrictions",
                table: "IdentityServerClientIdPRestrictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientGrantTypes",
                table: "IdentityServerClientGrantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientCorsOrigins",
                table: "IdentityServerClientCorsOrigins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerClientClaims",
                table: "IdentityServerClientClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerApiScopes",
                table: "IdentityServerApiScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerApiScopeProperties",
                table: "IdentityServerApiScopeProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerApiScopeClaims",
                table: "IdentityServerApiScopeClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerApiResourceSecrets",
                table: "IdentityServerApiResourceSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerApiResourceScopes",
                table: "IdentityServerApiResourceScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerApiResources",
                table: "IdentityServerApiResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerApiResourceProperties",
                table: "IdentityServerApiResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityServerApiResourceClaims",
                table: "IdentityServerApiResourceClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServerPersistedGrants",
                newName: "BsPersistedGrants");

            migrationBuilder.RenameTable(
                name: "IdentityServerIdentityResources",
                newName: "BsIdentityResources");

            migrationBuilder.RenameTable(
                name: "IdentityServerIdentityResourceProperties",
                newName: "BsIdentityResourceProperties");

            migrationBuilder.RenameTable(
                name: "IdentityServerIdentityResourceClaims",
                newName: "BsIdentityResourceClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServerDeviceFlowCodes",
                newName: "BsDeviceFlowCodes");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientSecrets",
                newName: "BsClientSecrets");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientScopes",
                newName: "BsClientScopes");

            migrationBuilder.RenameTable(
                name: "IdentityServerClients",
                newName: "BsClients");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientRedirectUris",
                newName: "BsClientRedirectUris");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientProperties",
                newName: "BsClientProperties");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientPostLogoutRedirectUris",
                newName: "BsClientPostLogoutRedirectUris");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientIdPRestrictions",
                newName: "BsClientIdPRestrictions");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientGrantTypes",
                newName: "BsClientGrantTypes");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientCorsOrigins",
                newName: "BsClientCorsOrigins");

            migrationBuilder.RenameTable(
                name: "IdentityServerClientClaims",
                newName: "BsClientClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServerApiScopes",
                newName: "BsApiScopes");

            migrationBuilder.RenameTable(
                name: "IdentityServerApiScopeProperties",
                newName: "BsApiScopeProperties");

            migrationBuilder.RenameTable(
                name: "IdentityServerApiScopeClaims",
                newName: "BsApiScopeClaims");

            migrationBuilder.RenameTable(
                name: "IdentityServerApiResourceSecrets",
                newName: "BsApiResourceSecrets");

            migrationBuilder.RenameTable(
                name: "IdentityServerApiResourceScopes",
                newName: "BsApiResourceScopes");

            migrationBuilder.RenameTable(
                name: "IdentityServerApiResources",
                newName: "BsApiResources");

            migrationBuilder.RenameTable(
                name: "IdentityServerApiResourceProperties",
                newName: "BsApiResourceProperties");

            migrationBuilder.RenameTable(
                name: "IdentityServerApiResourceClaims",
                newName: "BsApiResourceClaims");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServerPersistedGrants_SubjectId_SessionId_Type",
                table: "BsPersistedGrants",
                newName: "IX_BsPersistedGrants_SubjectId_SessionId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServerPersistedGrants_SubjectId_ClientId_Type",
                table: "BsPersistedGrants",
                newName: "IX_BsPersistedGrants_SubjectId_ClientId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServerPersistedGrants_Expiration",
                table: "BsPersistedGrants",
                newName: "IX_BsPersistedGrants_Expiration");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServerDeviceFlowCodes_UserCode",
                table: "BsDeviceFlowCodes",
                newName: "IX_BsDeviceFlowCodes_UserCode");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServerDeviceFlowCodes_Expiration",
                table: "BsDeviceFlowCodes",
                newName: "IX_BsDeviceFlowCodes_Expiration");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServerDeviceFlowCodes_DeviceCode",
                table: "BsDeviceFlowCodes",
                newName: "IX_BsDeviceFlowCodes_DeviceCode");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityServerClients_ClientId",
                table: "BsClients",
                newName: "IX_BsClients_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsPersistedGrants",
                table: "BsPersistedGrants",
                column: "Key");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsIdentityResources",
                table: "BsIdentityResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsIdentityResourceProperties",
                table: "BsIdentityResourceProperties",
                columns: new[] { "IdentityResourceId", "Key", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsIdentityResourceClaims",
                table: "BsIdentityResourceClaims",
                columns: new[] { "IdentityResourceId", "Type" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsDeviceFlowCodes",
                table: "BsDeviceFlowCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientSecrets",
                table: "BsClientSecrets",
                columns: new[] { "ClientId", "Type", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientScopes",
                table: "BsClientScopes",
                columns: new[] { "ClientId", "Scope" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClients",
                table: "BsClients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientRedirectUris",
                table: "BsClientRedirectUris",
                columns: new[] { "ClientId", "RedirectUri" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientProperties",
                table: "BsClientProperties",
                columns: new[] { "ClientId", "Key", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientPostLogoutRedirectUris",
                table: "BsClientPostLogoutRedirectUris",
                columns: new[] { "ClientId", "PostLogoutRedirectUri" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientIdPRestrictions",
                table: "BsClientIdPRestrictions",
                columns: new[] { "ClientId", "Provider" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientGrantTypes",
                table: "BsClientGrantTypes",
                columns: new[] { "ClientId", "GrantType" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientCorsOrigins",
                table: "BsClientCorsOrigins",
                columns: new[] { "ClientId", "Origin" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsClientClaims",
                table: "BsClientClaims",
                columns: new[] { "ClientId", "Type", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsApiScopes",
                table: "BsApiScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsApiScopeProperties",
                table: "BsApiScopeProperties",
                columns: new[] { "ApiScopeId", "Key", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsApiScopeClaims",
                table: "BsApiScopeClaims",
                columns: new[] { "ApiScopeId", "Type" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsApiResourceSecrets",
                table: "BsApiResourceSecrets",
                columns: new[] { "ApiResourceId", "Type", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsApiResourceScopes",
                table: "BsApiResourceScopes",
                columns: new[] { "ApiResourceId", "Scope" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsApiResources",
                table: "BsApiResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsApiResourceProperties",
                table: "BsApiResourceProperties",
                columns: new[] { "ApiResourceId", "Key", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BsApiResourceClaims",
                table: "BsApiResourceClaims",
                columns: new[] { "ApiResourceId", "Type" });

            migrationBuilder.AddForeignKey(
                name: "FK_BsApiResourceClaims_BsApiResources_ApiResourceId",
                table: "BsApiResourceClaims",
                column: "ApiResourceId",
                principalTable: "BsApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsApiResourceProperties_BsApiResources_ApiResourceId",
                table: "BsApiResourceProperties",
                column: "ApiResourceId",
                principalTable: "BsApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsApiResourceScopes_BsApiResources_ApiResourceId",
                table: "BsApiResourceScopes",
                column: "ApiResourceId",
                principalTable: "BsApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsApiResourceSecrets_BsApiResources_ApiResourceId",
                table: "BsApiResourceSecrets",
                column: "ApiResourceId",
                principalTable: "BsApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsApiScopeClaims_BsApiScopes_ApiScopeId",
                table: "BsApiScopeClaims",
                column: "ApiScopeId",
                principalTable: "BsApiScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsApiScopeProperties_BsApiScopes_ApiScopeId",
                table: "BsApiScopeProperties",
                column: "ApiScopeId",
                principalTable: "BsApiScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientClaims_BsClients_ClientId",
                table: "BsClientClaims",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientCorsOrigins_BsClients_ClientId",
                table: "BsClientCorsOrigins",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientGrantTypes_BsClients_ClientId",
                table: "BsClientGrantTypes",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientIdPRestrictions_BsClients_ClientId",
                table: "BsClientIdPRestrictions",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientPostLogoutRedirectUris_BsClients_ClientId",
                table: "BsClientPostLogoutRedirectUris",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientProperties_BsClients_ClientId",
                table: "BsClientProperties",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientRedirectUris_BsClients_ClientId",
                table: "BsClientRedirectUris",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientScopes_BsClients_ClientId",
                table: "BsClientScopes",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsClientSecrets_BsClients_ClientId",
                table: "BsClientSecrets",
                column: "ClientId",
                principalTable: "BsClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsIdentityResourceClaims_BsIdentityResources_IdentityResourceId",
                table: "BsIdentityResourceClaims",
                column: "IdentityResourceId",
                principalTable: "BsIdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BsIdentityResourceProperties_BsIdentityResources_IdentityResourceId",
                table: "BsIdentityResourceProperties",
                column: "IdentityResourceId",
                principalTable: "BsIdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
