package com.example.cinetec.DB;

import android.content.Context;
import android.database.DatabaseErrorHandler;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

public class Db_helper extends SQLiteOpenHelper {
    private static final int DATABASE_VERSION=1;
    private static final String DATABASE_NAME="agenda.db";
    private static final String TABLE_CONTACt="t_contact";
    public Db_helper(@Nullable Context context) {
        super(context, DATABASE_NAME, null,DATABASE_VERSION);
    }



    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        //sqLiteDatabase.execSQL();
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {

    }
}
