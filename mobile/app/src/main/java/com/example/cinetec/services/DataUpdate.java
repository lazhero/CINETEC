package com.example.cinetec.services;

import android.app.IntentService;
import android.content.Intent;
import android.content.Context;
import android.util.Log;

import androidx.annotation.Nullable;

import com.example.cinetec.DB.Db_helper;

import java.util.concurrent.TimeUnit;


public class DataUpdate extends IntentService {

    private final int TIME=2;
    private int TimeLeft;
    private Db_helper DB;
    public DataUpdate() {
        super("DataUpdate");
        DB=new Db_helper(this);
    }

    /**
     * waits some time a syncs the sqlite database with the server database
     * @param intent
     */
    @Override
    protected void onHandleIntent(Intent intent) {
        DB.SyncProcess();
       while(true){
           if(TimeLeft<=0){
               Log.d("Sincronizacion iniciada","sync");
               DB.SyncProcess();
               TimeLeft=TIME;

           }
           else{
               try{
                   TimeUnit.MINUTES.sleep(TimeLeft);
               }
               catch(Exception e){}
               TimeLeft=0;

           }
       }
    }

    /**
     * Adds on Sticky to tell the system to get the service back, if it was stopped due to the lack of resources
     * @param intent
     * @param flags
     * @param startId
     * @return
     */
    @Override
    public int onStartCommand(@Nullable Intent intent, int flags, int startId) {
        super.onStartCommand(intent, flags, startId);
        return START_REDELIVER_INTENT;
    }
}