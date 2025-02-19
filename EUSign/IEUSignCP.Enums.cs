namespace EUSignCP;

public enum EU_SUBJECT_TYPE
{
    UNDIFFERENCED = 0,
    CA = 1,
    CA_SERVER = 2,
    RA_ADMINISTRATOR = 3,
    END_USER = 4
};

public enum EU_SUBJECT_SUB_TYPE
{
    CA_SERVER_UNDIFFERENCED = 0,
    CA_SERVER_CMP = 1,
    CA_SERVER_TSP = 2,
    CA_SERVER_OCSP = 3,
};

public enum EU_KEY_MEDIA_SOURCE_TYPE
{
    OPERATOR = 1,
    FIXED = 2
};

public enum EU_KEYS_TYPE
{
    NONE = 0,
    DSTU_AND_ECDH_WITH_GOSTS = 1,
    RSA_WITH_SHA = 2,
    ECDSA_WITH_SHA = 4,
    DSTU_AND_ECDH_WITH_DSTU = 8
};

public enum EU_DS_UA_KEY_LENGTH
{
    EC_191 = 1,
    EC_257 = 2,
    EC_307 = 3,
    FILE = 4
}

public enum EU_KEP_UA_KEY_LENGTH
{
    EC_257 = 1,
    EC_431 = 2,
    EC_571 = 3,
    FILE = 4
}

public enum EU_DS_RSA_KEY_LENGTH
{
    RSA_1024 = 1,
    RSA_2048 = 2,
    RSA_3072 = 3,
    RSA_4096 = 4,
    FILE = 5
}

public enum EU_DS_ECDSA_KEY_LENGTH
{
    ECDSA_192 = 1,
    ECDSA_256 = 2,
    ECDSA_384 = 3,
    ECDSA_521 = 4,
    FILE = 5,
    ECDSA_CERT = 6
}

public enum EU_CERT_HASH_TYPE
{
    UNKNOWN = 0,
    GOST34311 = 1,
    SHA1 = 2,
    SHA224 = 3,
    SHA256 = 4,
    SHA384 = 5,
    SHA512 = 6,
    DSTU7564_256 = 7,
    DSTU7564_384 = 8,
    DSTU7564_512 = 9
};

public enum EU_CONTENT_ENC_ALGO_TYPE
{
    DEFAULT = 0,
    GOST28147_CFB = 2,
    TDES_CBC = 4,
    AES_128_CBC = 5,
    AES_192_CBC = 6,
    AES_256_CBC = 7,
    DSTU7624_256_OFB = 8,
    DSTU7624_256_CFB = 9
};

public enum EU_LANG
{
    DEFAULT = 0,
    UA = 1,
    RU = 2,
    EN = 3
};

public enum EU_ENCODING
{
    CP_ACP = 0,
    CP1251 = 1251,
    UTF8 = 65001
};

public enum EU_HEADER_PART_TYPE
{
    SIGNED = 1,
    ENCRYPTED = 2,
    STAMPED = 3,
    CERTCRYPT = 4
};

public enum EU_DEV_CTX_IDCARD_PASSWORD_VERSION
{
    VERSION_1 = 1,
    VERSION_2 = 2
};

public enum EU_DEV_CTX_IDCARD_DATA_ID
{
    DG1 = 0x01,
    DG2 = 0x02,
    DG3 = 0x03,
    DG4 = 0x04,
    DG5 = 0x05,
    DG6 = 0x06,
    DG7 = 0x07,
    DG8 = 0x08,
    DG9 = 0x09,
    DG10 = 0x0A,
    DG11 = 0x0B,
    DG12 = 0x0C,
    DG13 = 0x0D,
    DG14 = 0x0E,
    DG15 = 0x0F,
    DG16 = 0x10,
    DG17 = 0x11,
    DG18 = 0x12,

    SOD = 0x1D,
    COM = 0x1E,

    DG32 = 0x20,
    DG33 = 0x21,
    DG34 = 0x22,
    DG35 = 0x23,
    DG36 = 0x24,
    DG37 = 0x25,
    DG38 = 0x26
};

public enum EU_DEV_CTX_IDCARD_TERMINAL_TYPE
{
    UNDEFINED_TERMINAL = 0x00,
    AUTHENTICATION_TERMINAL = 0x01,
    SIGNATURE_TERMINAL = 0x02,
    INSPECTION_TERMINAL = 0x03
};

public enum EU_DEV_CTX_IDCARD_PASSWORD_TYPE
{
    UNDEFINED = 0x00,
    MRZ = 0x01,
    CAN = 0x02,
    PIN = 0x03,
    PUK = 0x04
};

public enum EU_CADES_TYPE
{
    UNKNOWN = 0,
    DETACHED = 1,
    ENVELOPED = 2
};

public enum EU_CADES_SIGN_LEVEL
{
    B_B = IEUSignCP.EU_SIGN_TYPE_CADES_BES,
    B_T = IEUSignCP.EU_SIGN_TYPE_CADES_T,
    B_LT = IEUSignCP.EU_SIGN_TYPE_CADES_X_LONG
}

public enum EU_ASIC_TYPE
{
    UNKNOWN = 0,
    S = 1,
    E = 2
};

public enum EU_ASIC_SIGN_TYPE
{
    UNKNOWN = 0,
    CADES = 1,
    XADES = 2
};

[Obsolete("EU_ASIC_SIGN_LEVEL is not supported, " +
    "use EU_CADES_SIGN_LEVEL or EU_XADES_SIGN_LEVEL instead.")]
public enum EU_ASIC_SIGN_LEVEL
{
    BES = 1,
    T = 4
};

public enum EU_XADES_TYPE
{
    UNKNOWN = 0,
    DETACHED = 1,
    ENVELOPING = 2,
    ENVELOPED = 3
};

public enum EU_XADES_SIGN_LEVEL
{
    BES = 1,    // Deprecated use B_B
    T = 4,      // Deprecated use B_T
    B_B = 1,
    B_T = 4,
    B_LT = 16,
    B_LTA = 32
};

public enum EU_PADES_SIGN_LEVEL
{
    BES = 1,    // Deprecated use B_B
    T = 4,      // Deprecated use B_T
    B_B = 1,
    B_T = 4,
    B_LT = 16,
    B_LTA = 32
};

public enum EU_SESSION_ENC_ALGO
{
    GOST28147 = 0,
    DSTU7624_256 = 1,
    DSTU7624_512 = 2,
    DSTU8845_256 = 3,
    DSTU8845_512 = 4
}

public enum EU_DEV_CTX_IS_KEYS_TYPE
{
    RSA_1024 = 0x11,
    RSA_1536 = 0x12,
    RSA_2048 = 0x13,
    RSA_3072 = 0x14,
    RSA_4096 = 0x15,
    EC_192 = 0x21,
    EC_224 = 0x22,
    EC_256 = 0x23,
    EC_384 = 0x24,
    EC_512 = 0x25,
    EC_521 = 0x26
}
