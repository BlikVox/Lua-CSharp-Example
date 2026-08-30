using Lua;
using Lua.Unity;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class LuaStateSample : MonoBehaviour
{
    private LuaState _luaState;
	private UniTask<LuaValue[]> _luaStateTask;

	[Header("Assets")]
	[SerializeField] private LuaAsset _luaAsset;

	private void Awake()
	{
		_luaState = LuaState.Create();
		_luaStateTask = _luaState.DoStringAsync(_luaAsset.Text).AsUniTask();
	}

	private void Update()
	{
		if (_luaStateTask.Status != UniTaskStatus.Succeeded) return;

	}

	public void ReloadScript()
	{
		_luaStateTask = _luaState.DoStringAsync(_luaAsset.Text).AsUniTask();
	}
}
