//=============================================================================

#if IOS
#if !__IOS__
#define __IOS__
#endif // __IOS__
#endif // IOS

#if ANDROID
#if !__ANDROID__
#define __ANDROID__
#endif // __ANDROID__
#endif // ANDROID

#if MACOS
#if !__MACOS__
#define __MACOS__
#endif // __MACOS__
#endif // MACOS

#if (__IOS__ || __ANDROID__ || __LINUX__ || __MACOS__)
#define OS_NIX
#endif

//=============================================================================

using System.Runtime.InteropServices;

//=============================================================================

#pragma warning disable CS8073
#pragma warning disable CS8600
#pragma warning disable CS8601
#pragma warning disable CS8603
#pragma warning disable CS8604
#pragma warning disable CS8605
#pragma warning disable CS8618
#pragma warning disable CS8625

namespace EUSignCP
{
#if !OS_NIX
    using DWORD = System.Int32;
#else // !OS_NIX
    using DWORD = System.IntPtr;
#endif // !OS_NIX

    public partial class IEUSignCP
    {
        class EUMarshalArrayOfBytesArrays : IDisposable
        {
            private bool _disposed = false;

            private EUMarshal _countPtr;
            private EUMarshal _arraysPtr;
            private EUMarshal _sizesPtr;
            private FreeArrayOfBytesArrays _free;

            public delegate void FreeArrayOfBytesArrays(
                DWORD count, IntPtr arrays, IntPtr arraysSizes);

            public EUMarshalArrayOfBytesArrays(FreeArrayOfBytesArrays free)
            {
                _countPtr = new EUMarshal(Marshal.SizeOf(typeof(DWORD)));
                _arraysPtr = new EUMarshal(Marshal.SizeOf(typeof(IntPtr)));
                Marshal.WriteIntPtr(_arraysPtr.DataPtr, IntPtr.Zero);
                _sizesPtr = new EUMarshal(Marshal.SizeOf(typeof(IntPtr)));
                Marshal.WriteIntPtr(_sizesPtr.DataPtr, IntPtr.Zero);
                _free = free;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            ~EUMarshalArrayOfBytesArrays()
            {
                Dispose(false);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                    return;

                FreeData();

                if (disposing)
                {
                    if (_countPtr != null)
                        _countPtr.Dispose();
                    if (_arraysPtr != null)
                        _arraysPtr.Dispose();
                    if (_sizesPtr != null)
                        _sizesPtr.Dispose();
                }

                _disposed = true;
            }

            public IntPtr CountPtr
            {
                get
                {
                    return _countPtr.DataPtr;
                }
            }

            public IntPtr ArraysPtr
            {
                get
                {
                    return _arraysPtr.DataPtr;
                }
            }

            public IntPtr ArraysLengthesPtr
            {
                get
                {
                    return _sizesPtr.DataPtr;
                }
            }

            public byte[][] GetBinaryDataArrays(bool freeData)
            {
                byte[][] arrays;

                int count = _countPtr.GetDWORDData(false);
                IntPtr arraysPtr = _arraysPtr.GetPointerData(false);
                IntPtr sizesPtr = _sizesPtr.GetPointerData(false);
                IntPtr arrayPtr;
                int arraySize;
                byte[] array;

                arrays = new byte[count][];

                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        arraysPtr = EUMarshal.ReadIntPtr(arraysPtr, out arrayPtr);
                        sizesPtr = EUMarshal.ReadDWORD(sizesPtr, out arraySize);
                        array = new byte[arraySize];
                        Marshal.Copy(arrayPtr, array, 0, arraySize);

                        arrays[i] = array;
                    }
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }

                if (freeData)
                    FreeData();

                return arrays;
            }

            public void FreeData()
            {
                if (_countPtr != null && _arraysPtr != null && _sizesPtr != null)
                {
                    try {
                        _free((DWORD)_countPtr.GetDWORDData(),
                            _arraysPtr.GetPointerData(),
                            _sizesPtr.GetPointerData());
                    } catch (Exception)
                    {
                    }
                }

                if (_countPtr != null)
                {
                    _countPtr.Dispose();
                    _countPtr = null;
                }

                if (_arraysPtr != null)
                {
                    _arraysPtr.Dispose();
                    _arraysPtr = null;
                }

                if (_sizesPtr != null)
                {
                    _sizesPtr.Dispose();
                    _sizesPtr = null;
                }
            }
        }
    }
}

//=============================================================================
