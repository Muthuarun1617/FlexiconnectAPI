namespace Flexiconnect.Shared.Constants
{
    public static class DBConstants  
    {
        public const string DBConnString = "NextgenConn";
        public const string FetchActionMenuSP = "dbo.sp_fetch_actionmenu";
        public const string InsertActionMenuSP = "dbo.sp_insert_actionmenu";
        public const string UpdateActionMenuSP = "dbo.sp_update_actionmenu";
        public const string DeleteActionMenuSP = "dbo.sp_delete_actionmenu";
        public const string FetchActionPermissionSP = "dbo.sp_fetch_permission";
        public const string InsertActionPermissionSP = "dbo.sp_insert_permission";
        public const string UpdateActionPermissionSP = "dbo.sp_update_permission";
        public const string DeleteActionPermissionSP = "dbo.sp_delete_permission";
        public const string FetchActionRoleMappingSP = "dbo.sp_fetch_rolemapping";
        public const string InsertUpdateActionRoleMappingSP = "dbo.sp_insert_update_rolemapping";

        public const string GetDealerByRole = "dbo.sp_GetDealerByRole";
        public const string GetFilterProduct = "dbo.sp_GetProductFilterByDealerCode";
        public const string GetProductCatalogue = "dbo.sp_GetProductCatelogue";
        public const string GetFrequentlyOrderProducts = "dbo.Sp_GetFrequentlyOrderProduct";
        public const string ProductDetailsByVariant = "dbo.sp_GetProductDetailsByVariant";
        public const string ProductVariant = "dbo.sp_GetProductVariants";

        public const string FetchActionRoleUserMappingSP = "dbo.sp_fetch_roleusermapping";
        public const string InsertUpdateActionRoleUserMappingSP = "dbo.sp_insert_update_roleusermapping";

    }
}
